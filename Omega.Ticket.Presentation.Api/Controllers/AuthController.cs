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
using System.Security.Claims;
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
            User objUser = await _authService.Login(loginDTO.Username, loginDTO.Password);

            if (objUser == null)
                return Unauthorized();
            else
                return await _authService.GetToken(objUser);
        }

        [HttpPost]
        public async Task<ActionResult<TokenDTO>> Register(RegisterDTO registerDTO)
        {
            User objUser = await _userService.FindByEmailOrPhone(registerDTO.Email, registerDTO.Phone);

            if (objUser != null)
                return Conflict(new { Message = "El email o teléfono ya se encuentran registrados" });
            else
            {
                objUser = await _authService.Register(registerDTO);

                if(objUser.Id == 0)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "No se pudo insertar el usuario" });
                else
                    return await _authService.GetToken(objUser);
            }
        }

        public async Task<ActionResult<TokenDTO>> RefreshToken(TokenDTO tokenDTO)
        {
            string response = await _authService.VerifyToken(tokenDTO);

            if (response != null)
                return BadRequest(new { Message = response });
            else
            {
                User objUser = await _userService.FindById(int.Parse(ClaimTypes.NameIdentifier));
                return await _authService.GetToken(objUser);
            }
        }
    }
}
