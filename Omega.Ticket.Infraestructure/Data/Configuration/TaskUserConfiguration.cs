using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omega.Ticket.Infraestructure.Data.Configuration
{
    public class TaskUserConfiguration : IEntityTypeConfiguration<TaskUser>
    {
        public void Configure(EntityTypeBuilder<TaskUser> entity)
        {
            entity.HasKey(e => new { e.TaskId, e.UserId });

            entity.ToTable("Task_User", "Fact");

            entity.HasOne(d => d.Task)
                .WithMany(p => p.TaskUsers)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_User_Task");

            entity.HasOne(d => d.User)
                .WithMany(p => p.TaskUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_User_User");
        }
    }
}
