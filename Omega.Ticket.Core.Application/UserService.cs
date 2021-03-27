using Microsoft.EntityFrameworkCore;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using Omega.Ticket.Transversal;
using System.Linq;
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

        public async Task<User> FindByEmailOrPhone(string email, string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email || x.Phone == phone);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
