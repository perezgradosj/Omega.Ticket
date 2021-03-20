using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Project
    {
        public Project()
        {
            ProjectUsers = new HashSet<ProjectUser>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrganizationId { get; set; }
        public int StateId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
