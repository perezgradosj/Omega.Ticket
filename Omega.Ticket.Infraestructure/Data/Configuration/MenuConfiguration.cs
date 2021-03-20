using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> entity)
        {
            entity.ToTable("Menu", "Seg");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.State)
                .WithMany(p => p.Menus)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_State");
        }
    }
}
