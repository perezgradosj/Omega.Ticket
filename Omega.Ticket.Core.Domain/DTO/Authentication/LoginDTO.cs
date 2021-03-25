using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Core.Domain.DTO.Authentication
{
    public class LoginDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
