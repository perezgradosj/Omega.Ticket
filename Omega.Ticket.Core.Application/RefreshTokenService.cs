using Microsoft.EntityFrameworkCore;
using Omega.Ticket.Core.Domain.Entities;
using Omega.Ticket.Core.Domain.Interfaces;
using Omega.Ticket.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Application
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IOmegaTicketContext _context;
        public RefreshTokenService(IOmegaTicketContext context)
        {
            _context = context;
        }
        public async Task<RefreshToken> FindByUserId(int userId)
        {
            return await _context.RefreshToken.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<int> Delete(RefreshToken objRefreshToken)
        {
            _context.RefreshToken.Remove(objRefreshToken);
            return await _context.SaveChangesAsync();
        }
    }
}
