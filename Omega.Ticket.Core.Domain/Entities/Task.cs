using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Task
    {
        public Task()
        {
            TaskUsers = new HashSet<TaskUser>();
        }

        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaskUser> TaskUsers { get; set; }
    }
}
