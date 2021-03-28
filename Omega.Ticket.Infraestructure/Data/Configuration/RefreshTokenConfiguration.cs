using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.ToTable("RefreshToken", "Seg");

            entity.Property(e => e.UserId)
               .IsRequired()
               .IsUnicode(false);

            entity.Property(e => e.Token)
              .IsRequired()
              .IsUnicode(false);

            entity.Property(e => e.Expires)
              .IsRequired()
              .IsUnicode(false);
        }
    }
}
