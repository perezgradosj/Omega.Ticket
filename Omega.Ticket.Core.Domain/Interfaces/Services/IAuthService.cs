using Omega.Ticket.Core.Domain.DTO.Authentication;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Core.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        TokenDTO GetToken(User objUser);
    }
}
