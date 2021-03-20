using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Core.Domain.Entities.Ticket>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.Ticket> entity)
        {
            entity.ToTable("Ticket", "Fact");

            entity.Property(e => e.Code)
                .HasMaxLength(31)
                .IsUnicode(false)
                .HasComputedColumnSql("('T'+CONVERT([varchar],[id]))", false);

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.EstimatedDateEnded).HasColumnType("datetime");

            entity.Property(e => e.RealDateEnded).HasColumnType("datetime");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.HasOne(d => d.Difficulty)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.DifficultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Difficulty");

            entity.HasOne(d => d.Organization)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Organization");

            entity.HasOne(d => d.Priority)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Priority");

            entity.HasOne(d => d.Project)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Project");

            entity.HasOne(d => d.State)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_State");

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Type");

            entity.HasOne(d => d.UserCreatorNavigation)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_User");
        }
    }
}
