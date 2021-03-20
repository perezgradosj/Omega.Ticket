using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class TicketUser
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
