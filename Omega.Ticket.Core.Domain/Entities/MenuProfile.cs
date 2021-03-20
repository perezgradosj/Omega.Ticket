using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class MenuProfile
    {
        public int MenuId { get; set; }
        public int ProfileId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
