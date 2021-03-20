using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Reference
    {
        public Reference()
        {
            Attacheds = new HashSet<Attached>();
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attached> Attacheds { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
