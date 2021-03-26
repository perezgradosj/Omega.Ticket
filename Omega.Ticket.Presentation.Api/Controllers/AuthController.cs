using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.DTO.User;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using Omega.Ticket.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            //1. Buscamos el usuario
            User objUser = await _userService.FindByEmailOrPhone(loginDTO.User);

            if (objUser == null)
                return NotFound();
            else
            {
                //2. Comparamos las claves
                byte[] passwordEncrypt = Cryptographic.HashPasswordWidthSalt(Encoding.UTF8.GetBytes(loginDTO.Password), objUser.Salt);

                if (passwordEncrypt.SequenceEqual(objUser.Password))
                {
                    //3. Creamos el token
                    TokenDTO objToken = _authService.GetToken(objUser);
                    return Ok(objToken);
                }                    

                return Forbid();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TokenDTO>> Register(CreateUserDTO createUserDTO)
        {
            //1. Mapeamos 
            User objUser = _mapper.Map<User>(createUserDTO);

            //2. Encriptamos la clave
            objUser.Salt = Cryptographic.GenerateSalt();
            objUser.Password = Cryptographic.HashPasswordWidthSalt(Encoding.UTF8.GetBytes(createUserDTO.PasswordDecrypted), objUser.Salt);

            //3. Creamos el usuario
            objUser = await _userService.Create(objUser);

            //4. Creamos el token
            TokenDTO objToken = _authService.GetToken(objUser);

            return Ok(objToken);
        }
    }
}
