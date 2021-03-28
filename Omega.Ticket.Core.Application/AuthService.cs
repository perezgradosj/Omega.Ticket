using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.DTO.User;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using Omega.Ticket.Transversal;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Application
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IOmegaTicketContext _context;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public AuthService(IOptions<AppSettings> appSettings, IOmegaTicketContext context, TokenValidationParameters tokenValidationParameters)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _tokenValidationParameters = tokenValidationParameters;
        }

        private string GenerateAccessToken(ClaimsIdentity claims)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        private async Task<RefreshToken> GenerateRefreshToken(User objUser)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                string refreshToken = Convert.ToBase64String(randomBytes);

                RefreshToken objRefreshToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.UserId == objUser.Id);

                if(objRefreshToken == null)
                {
                    objRefreshToken = new RefreshToken
                    {
                        Token = refreshToken,
                        Expires = DateTime.Now.AddDays(7),
                        UserId = objUser.Id
                    };
                    await _context.RefreshToken.AddAsync(objRefreshToken);
                }
                else
                {
                    objRefreshToken.Token = refreshToken;
                    objRefreshToken.Expires = DateTime.Now.AddDays(7);
                }                
                await _context.SaveChangesAsync();

                return objRefreshToken;
            }
        }               

        public async Task<TokenDTO> GetToken(User objUser)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, objUser.Id.ToString()),
                new Claim(ClaimTypes.Email, objUser.Email)
            });

            RefreshToken objRefreshToken = await GenerateRefreshToken(objUser);

            return new TokenDTO
            {
                AccessToken = GenerateAccessToken(claims),
                RefreshToken = objRefreshToken.Token
            };
        }

        public async Task<User> Login(string username, string password)
        {
            User objUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == username || x.Phone == username);

            if (objUser == null)
                return null;

            byte[] passwordEncrypt = Cryptographic.HashPasswordWidthSalt(Encoding.UTF8.GetBytes(password), objUser.Salt);

            if (!passwordEncrypt.SequenceEqual(objUser.Password))
                return null;
            else
                return objUser;
        }

        public async Task<User> Register(RegisterDTO registerDTO)
        {
            var objUser = new User();
            objUser.Email = registerDTO.Email;
            objUser.Phone = registerDTO.Phone;
            objUser.LastName = registerDTO.LastName;
            objUser.FirstName = registerDTO.FirstName;
            objUser.Salt = Cryptographic.GenerateSalt();
            objUser.Password = Cryptographic.HashPasswordWidthSalt(Encoding.UTF8.GetBytes(registerDTO.Password), objUser.Salt);
            objUser.ProfileId = Constants.Profile.Cliente;
            objUser.StateId = Constants.State.Activo;

            await _context.Users.AddAsync(objUser);
            await _context.SaveChangesAsync();

            return objUser;
        }

        private VerifyTokenDTO VerifyAccessToken(string accessToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            jwtTokenHandler.ValidateToken(accessToken, _tokenValidationParameters, out SecurityToken validatedAccessToken);

            if (validatedAccessToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (result == false)
                {
                    return new VerifyTokenDTO
                    {
                        Error = true,
                        Message = "Invalid token"
                    };
                }
            }
            return new VerifyTokenDTO
            {
                Error = true,
                Message = "We cannot refresh this since the token has not expired"
            };
        }

        private async Task<VerifyTokenDTO> VerifyRefreshToken(TokenDTO tokenDTO)
        {
            RefreshToken objRefreshToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == tokenDTO.RefreshToken);

            if (objRefreshToken == null)
            {
                return new VerifyTokenDTO
                {
                    Error = true,
                    Message = "refresh token doesnt exist"
                };
            }

            if (DateTime.Now >= objRefreshToken.Expires)
            {
                return new VerifyTokenDTO
                {
                    Error = true,
                    Message = "token has expired, user needs to relogin"
                };
            }

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken tokenDecode = jwtTokenHandler.ReadJwtToken(tokenDTO.AccessToken);
            string userId = tokenDecode.Claims.First(claim => claim.Type == "nameid").Value;

            if (objRefreshToken.UserId != int.Parse(userId))
            {
                return new VerifyTokenDTO
                {
                    Error = true,
                    Message = "the token doenst mateched the saved token"
                };
            }

            return new VerifyTokenDTO
            {
                UserId = int.Parse(userId)
            };
        }

        public async Task<VerifyTokenDTO> VerifyToken(TokenDTO tokenDTO)
        {
            try
            {
                return VerifyAccessToken(tokenDTO.AccessToken);
            }
            catch (SecurityTokenExpiredException)
            {
                return await VerifyRefreshToken(tokenDTO);
            }
        }
    }
}
