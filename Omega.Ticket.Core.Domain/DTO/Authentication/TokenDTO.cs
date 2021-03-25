using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Core.Domain.DTO.Authentication
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
