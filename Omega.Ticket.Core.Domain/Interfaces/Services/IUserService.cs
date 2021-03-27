using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> FindByEmailOrPhone(string email, string phone);        
        Task<User> FindById(int id);        
    }
}
