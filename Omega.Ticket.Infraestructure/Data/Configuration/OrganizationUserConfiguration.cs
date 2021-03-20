using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class OrganizationUserConfiguration : IEntityTypeConfiguration<OrganizationUser>
    {
        public void Configure(EntityTypeBuilder<OrganizationUser> entity)
        {
            entity.HasKey(e => new { e.OrganizationId, e.UserId });

            entity.ToTable("Organization_User", "Dim");

            entity.HasOne(d => d.Organization)
                .WithMany(p => p.OrganizationUsers)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organization_User_Organization");

            entity.HasOne(d => d.User)
                .WithMany(p => p.OrganizationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organization_User_User");
        }
    }
}
