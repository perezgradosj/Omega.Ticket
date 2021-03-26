using Microsoft.EntityFrameworkCore;
using Omega.Ticket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Ticket.Core.Domain.Interfaces
{
    public interface IOmegaTicketContext
    {
        DbSet<Attached> Attacheds { get; set; }
        DbSet<Difficulty> Difficulties { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<MenuProfile> MenuProfiles { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<OrganizationUser> OrganizationUsers { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectUser> ProjectUsers { get; set; }
        DbSet<Reference> References { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Core.Domain.Entities.Task> Tasks { get; set; }
        DbSet<TaskUser> TaskUsers { get; set; }
        DbSet<Core.Domain.Entities.Ticket> Tickets { get; set; }
        DbSet<TicketUser> TicketUsers { get; set; }
        DbSet<Core.Domain.Entities.Type> Types { get; set; }
        DbSet<User> Users { get; set; }

        System.Threading.Tasks.Task<int> SaveChangesAsync();
    }
}
