using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Domain.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> FindByUserId(int userId);
        Task<int> Delete(RefreshToken objRefreshToken);
    }
}
