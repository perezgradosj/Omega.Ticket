using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class OrganizationUser
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
    }
}
