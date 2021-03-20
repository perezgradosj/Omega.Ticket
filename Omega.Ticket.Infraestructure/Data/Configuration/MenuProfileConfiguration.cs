using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class MenuProfileConfiguration : IEntityTypeConfiguration<MenuProfile>
    {
        public void Configure(EntityTypeBuilder<MenuProfile> entity)
        {
            entity.HasKey(e => new { e.MenuId, e.ProfileId })
                    .HasName("PK__Menu_Pro__9B0E1ABE94F155B6");

            entity.ToTable("Menu_Profile", "Seg");

            entity.HasOne(d => d.Menu)
                .WithMany(p => p.MenuProfiles)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu_Prof__MenuI__30F848ED");

            entity.HasOne(d => d.Profile)
                .WithMany(p => p.MenuProfiles)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu_Prof__Profi__31EC6D26");
        }
    }
}
