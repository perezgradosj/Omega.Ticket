using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Attached
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Size { get; set; }
        public int DynamicTableId { get; set; }
        public int ReferenceId { get; set; }

        public virtual Reference Reference { get; set; }
    }
}
