using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            MenuProfiles = new HashSet<MenuProfile>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool Main { get; set; }
        public int? Father { get; set; }
        public bool Children { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<MenuProfile> MenuProfiles { get; set; }
    }
}
