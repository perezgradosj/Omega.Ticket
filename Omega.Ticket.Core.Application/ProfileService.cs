using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using System;

namespace Omega.Ticket.Core.Application
{
    public class ProfileService : IProfileService
    {
        private readonly IOmegaTicketContext _context;
        public ProfileService(IOmegaTicketContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task Create(Profile obj)
        {
            _context.Profiles.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
