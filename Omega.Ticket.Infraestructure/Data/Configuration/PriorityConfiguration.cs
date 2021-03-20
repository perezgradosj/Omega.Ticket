using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> entity)
        {
            entity.ToTable("Priority", "Mtro");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
