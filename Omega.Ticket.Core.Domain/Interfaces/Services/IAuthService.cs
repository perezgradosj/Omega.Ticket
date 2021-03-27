using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.DTO.User;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> Login(string username, string password);
        Task<User> Register(RegisterDTO registerDTO);
        Task<string> VerifyToken(TokenDTO tokenDTO);
        Task<TokenDTO> GetToken(User objUser);
    }
}
