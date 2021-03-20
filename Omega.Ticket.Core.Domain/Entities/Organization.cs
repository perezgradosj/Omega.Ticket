using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            OrganizationUsers = new HashSet<OrganizationUser>();
            Projects = new HashSet<Project>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserCreator { get; set; }

        public virtual User UserCreatorNavigation { get; set; }
        public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
