using Microsoft.EntityFrameworkCore;
using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Application
{
    public class UserService : IUserService
    {
        private readonly IOmegaTicketContext _context;
        public UserService(IOmegaTicketContext context)
        {
            _context = context;
        }

        public async Task<User> FindByEmailOrPhone(string user)
        {
            return await _context.Users.Where(x => x.Email == user || x.Phone == user).FirstOrDefaultAsync();
        }

        public async Task<TokenDTO> GetToken(User objUser)
        {
            throw new NotImplementedException();
        }
    }
}
