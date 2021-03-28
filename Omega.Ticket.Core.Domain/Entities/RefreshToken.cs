using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Core.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
