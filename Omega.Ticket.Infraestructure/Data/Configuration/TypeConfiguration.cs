using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class TypeConfiguration : IEntityTypeConfiguration<Core.Domain.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.Type> entity)
        {
            entity.ToTable("Type", "Mtro");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
