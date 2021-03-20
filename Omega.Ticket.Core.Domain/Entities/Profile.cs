using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Profile
    {
        public Profile()
        {
            MenuProfiles = new HashSet<MenuProfile>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuProfile> MenuProfiles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
