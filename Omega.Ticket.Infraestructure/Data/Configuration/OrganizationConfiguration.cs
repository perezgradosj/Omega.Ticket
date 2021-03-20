using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entity)
        {
            entity.ToTable("Organization", "Dim");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserCreatorNavigation)
                .WithMany(p => p.Organizations)
                .HasForeignKey(d => d.UserCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organization_User");
        }
    }
}
