using System;
using System.Collections.Generic;

#nullable disable

namespace Omega.Ticket.Core.Domain.Entities
{
    public partial class Ticket
    {
        public Ticket()
        {
            Messages = new HashSet<Message>();
            TicketUsers = new HashSet<TicketUser>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int DifficultyId { get; set; }
        public int PriorityId { get; set; }
        public int Hours { get; set; }
        public DateTime EstimatedDateEnded { get; set; }
        public DateTime RealDateEnded { get; set; }
        public int OrganizationId { get; set; }
        public int ProjectId { get; set; }
        public int UserCreator { get; set; }
        public DateTime CreationDate { get; set; }
        public int StateId { get; set; }

        public virtual Difficulty Difficulty { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual State State { get; set; }
        public virtual Type Type { get; set; }
        public virtual User UserCreatorNavigation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<TicketUser> TicketUsers { get; set; }
    }
}
