using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class TicketUserConfiguration : IEntityTypeConfiguration<TicketUser>
    {
        public void Configure(EntityTypeBuilder<TicketUser> entity)
        {
            entity.HasKey(e => new { e.TicketId, e.UserId });

            entity.ToTable("Ticket_User", "Fact");

            entity.HasOne(d => d.Ticket)
                .WithMany(p => p.TicketUsers)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User_Ticket");

            entity.HasOne(d => d.User)
                .WithMany(p => p.TicketUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User_User");
        }
    }
}
