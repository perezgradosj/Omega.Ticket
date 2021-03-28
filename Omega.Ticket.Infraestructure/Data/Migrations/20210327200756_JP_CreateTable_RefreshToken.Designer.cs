﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Omega.Ticket.Infraestructure.Data;

namespace Omega.Ticket.Infraestructure.Data.Migrations
{
    [DbContext(typeof(OmegaTicketContext))]
    [Migration("20210327200756_JP_CreateTable_RefreshToken")]
    partial class JP_CreateTable_RefreshToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Attached", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DynamicTableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Size")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceId");

                    b.ToTable("Attached", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Difficulty", "Mtro");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Children")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Controller")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Father")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Main")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Menu", "Seg");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.MenuProfile", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "ProfileId")
                        .HasName("PK__Menu_Pro__9B0E1ABE94F155B6");

                    b.HasIndex("ProfileId");

                    b.ToTable("Menu_Profile", "Seg");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Message", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserCreator")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreator");

                    b.ToTable("Organization", "Dim");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.OrganizationUser", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Organization_User", "Dim");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Priority", "Mtro");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "UQ_Name")
                        .IsUnique();

                    b.ToTable("Profile", "Seg");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("StateId");

                    b.ToTable("Project", "Dim");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.ProjectUser", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Project_User", "Dim");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Reference", "Mtro");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Expires")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("UserId")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RefreshToken", "Seg");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceId");

                    b.HasIndex(new[] { "Id" }, "UQ_Name")
                        .IsUnique()
                        .HasDatabaseName("UQ_Name1");

                    b.ToTable("State", "Mtro");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Task", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.TaskUser", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Task_User", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(31)
                        .IsUnicode(false)
                        .HasColumnType("varchar(31)")
                        .HasComputedColumnSql("('T'+CONVERT([varchar],[id]))", false);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedDateEnded")
                        .HasColumnType("datetime");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RealDateEnded")
                        .HasColumnType("datetime");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserCreator")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StateId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserCreator");

                    b.ToTable("Ticket", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.TicketUser", b =>
                {
                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TicketId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Ticket_User", "Fact");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Type", "Mtro");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("StateId");

                    b.HasIndex(new[] { "Email" }, "UQ_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "UQ_Phone")
                        .IsUnique();

                    b.ToTable("User", "Seg");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Attached", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Reference", "Reference")
                        .WithMany("Attacheds")
                        .HasForeignKey("ReferenceId")
                        .HasConstraintName("FK_Attached_Reference")
                        .IsRequired();

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Menu", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.State", "State")
                        .WithMany("Menus")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_Menu_State")
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.MenuProfile", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Menu", "Menu")
                        .WithMany("MenuProfiles")
                        .HasForeignKey("MenuId")
                        .HasConstraintName("FK__Menu_Prof__MenuI__30F848ED")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Profile", "Profile")
                        .WithMany("MenuProfiles")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK__Menu_Prof__Profi__31EC6D26")
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Message", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Messages")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_Message_Ticket")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Message_User")
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Organization", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "UserCreatorNavigation")
                        .WithMany("Organizations")
                        .HasForeignKey("UserCreator")
                        .HasConstraintName("FK_Organization_User")
                        .IsRequired();

                    b.Navigation("UserCreatorNavigation");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.OrganizationUser", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Organization", "Organization")
                        .WithMany("OrganizationUsers")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK_Organization_User_Organization")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "User")
                        .WithMany("OrganizationUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Organization_User_User")
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Project", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Organization", "Organization")
                        .WithMany("Projects")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK_Project_Organization")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.State", "State")
                        .WithMany("Projects")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_Project_State")
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.ProjectUser", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Project_User_Project")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Project_User_User")
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.State", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Reference", "Reference")
                        .WithMany("States")
                        .HasForeignKey("ReferenceId")
                        .HasConstraintName("FK__State__Reference__300424B4")
                        .IsRequired();

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.TaskUser", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Task", "Task")
                        .WithMany("TaskUsers")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK_Task_User_Task")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "User")
                        .WithMany("TaskUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Task_User_User")
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Difficulty", "Difficulty")
                        .WithMany("Tickets")
                        .HasForeignKey("DifficultyId")
                        .HasConstraintName("FK_Ticket_Difficulty")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Organization", "Organization")
                        .WithMany("Tickets")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK_Ticket_Organization")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Priority", "Priority")
                        .WithMany("Tickets")
                        .HasForeignKey("PriorityId")
                        .HasConstraintName("FK_Ticket_Priority")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Ticket_Project")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.State", "State")
                        .WithMany("Tickets")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_Ticket_State")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Type", "Type")
                        .WithMany("Tickets")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Ticket_Type")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "UserCreatorNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("UserCreator")
                        .HasConstraintName("FK_Ticket_User")
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Organization");

                    b.Navigation("Priority");

                    b.Navigation("Project");

                    b.Navigation("State");

                    b.Navigation("Type");

                    b.Navigation("UserCreatorNavigation");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.TicketUser", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Ticket", "Ticket")
                        .WithMany("TicketUsers")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_Ticket_User_Ticket")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.User", "User")
                        .WithMany("TicketUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Ticket_User_User")
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("Omega.Ticket.Core.Domain.Entities.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK__User__ProfileId__32E0915F")
                        .IsRequired();

                    b.HasOne("Omega.Ticket.Core.Domain.Entities.State", "State")
                        .WithMany("Users")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK__User__StateId__33D4B598")
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Difficulty", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Menu", b =>
                {
                    b.Navigation("MenuProfiles");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Organization", b =>
                {
                    b.Navigation("OrganizationUsers");

                    b.Navigation("Projects");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Priority", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Profile", b =>
                {
                    b.Navigation("MenuProfiles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectUsers");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Reference", b =>
                {
                    b.Navigation("Attacheds");

                    b.Navigation("States");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.State", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Projects");

                    b.Navigation("Tickets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Task", b =>
                {
                    b.Navigation("TaskUsers");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Ticket", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("TicketUsers");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.Type", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Omega.Ticket.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Organizations");

                    b.Navigation("OrganizationUsers");

                    b.Navigation("ProjectUsers");

                    b.Navigation("TaskUsers");

                    b.Navigation("Tickets");

                    b.Navigation("TicketUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
