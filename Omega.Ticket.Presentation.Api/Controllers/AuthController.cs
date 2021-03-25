using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omega.Ticket.Core.Domain.DTO.Authentication;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            User objUser = await _userService.FindByEmailOrPhone(loginDTO.User);

            if (objUser == null)
                return NotFound();
            else
            {
                byte[] passwordEncrypt = Cryptographic.HashPasswordWidthSalt(Encoding.UTF8.GetBytes(loginDTO.Password), objUser.Salt);

                if (passwordEncrypt.SequenceEqual(objUser.Password))
                    return await _userService.GetToken(objUser);

                return Forbid();
            }
        }
    }
}
