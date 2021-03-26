using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using Omega.Ticket.Transversal;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Omega.Ticket.Core.Application
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public TokenDTO GetToken(User objUser)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, objUser.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Email, objUser.Email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            string bearerToken = tokenHandler.WriteToken(createdToken);

            return new TokenDTO { AccessToken = bearerToken };
        }
    }
}
