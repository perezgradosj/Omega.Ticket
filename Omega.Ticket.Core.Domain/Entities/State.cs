using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class State
    {
        public State()
        {
            Menus = new HashSet<Menu>();
            Projects = new HashSet<Project>();
            Tickets = new HashSet<Ticket>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ReferenceId { get; set; }

        public virtual Reference Reference { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
