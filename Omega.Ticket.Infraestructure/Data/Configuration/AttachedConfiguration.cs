using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class AttachedConfiguration : IEntityTypeConfiguration<Attached>
    {
        public void Configure(EntityTypeBuilder<Attached> entity)
        {
            entity.ToTable("Attached", "Fact");

            entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.Size).IsRequired();

            entity.HasOne(d => d.Reference)
                .WithMany(p => p.Attacheds)
                .HasForeignKey(d => d.ReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attached_Reference");
        }
    }
}
