using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            OrganizationUsers = new HashSet<OrganizationUser>();
            Organizations = new HashSet<Organization>();
            ProjectUsers = new HashSet<ProjectUser>();
            TaskUsers = new HashSet<TaskUser>();
            TicketUsers = new HashSet<TicketUser>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public int ProfileId { get; set; }
        public int StateId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
        public virtual ICollection<TaskUser> TaskUsers { get; set; }
        public virtual ICollection<TicketUser> TicketUsers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
