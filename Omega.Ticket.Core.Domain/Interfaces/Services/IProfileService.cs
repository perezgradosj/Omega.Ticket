using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Domain.Interfaces.Services
{
    public interface IProfileService
    {
        System.Threading.Tasks.Task Create(Profile obj);

        Task<Profile> FindById(int id);
    }
}
