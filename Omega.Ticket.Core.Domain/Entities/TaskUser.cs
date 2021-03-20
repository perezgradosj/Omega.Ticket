using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class TaskUser
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
