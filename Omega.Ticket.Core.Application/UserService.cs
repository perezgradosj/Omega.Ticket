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

        public async System.Threading.Tasks.Task<User> Create(User objUser)
        {
            objUser.StateId = Constants.State.Activo; 
            _context.Users.Add(objUser);
            await _context.SaveChangesAsync();
            return objUser;
        }

        public async Task<User> FindByEmailOrPhone(string user)
        {
            return await _context.Users.Where(x => x.Email == user || x.Phone == user).FirstOrDefaultAsync();
        }
    }
}
