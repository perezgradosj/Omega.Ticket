using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Omega.Ticket.Infraestructure.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fact");

            migrationBuilder.EnsureSchema(
                name: "Mtro");

            migrationBuilder.EnsureSchema(
                name: "Seg");

            migrationBuilder.EnsureSchema(
                name: "Dim");

            migrationBuilder.CreateTable(
                name: "Difficulty",
                schema: "Mtro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "Mtro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "Seg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                schema: "Mtro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "Fact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "Mtro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Attached",
                schema: "Fact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Size = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DynamicTableId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attached", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attached_Reference",
                        column: x => x.ReferenceId,
                        principalSchema: "Mtro",
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "Mtro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK__State__Reference__300424B4",
                        column: x => x.ReferenceId,
                        principalSchema: "Mtro",
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Seg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    Father = table.Column<int>(type: "int", nullable: true),
                    Children = table.Column<bool>(type: "bit", nullable: false),
                    Controller = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Action = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_State",
                        column: x => x.StateId,
                        principalSchema: "Mtro",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Seg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Photo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK__User__ProfileId__32E0915F",
                        column: x => x.ProfileId,
                        principalSchema: "Seg",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__User__StateId__33D4B598",
                        column: x => x.StateId,
                        principalSchema: "Mtro",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Profile",
                schema: "Seg",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Menu_Pro__9B0E1ABE94F155B6", x => new { x.MenuId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK__Menu_Prof__MenuI__30F848ED",
                        column: x => x.MenuId,
                        principalSchema: "Seg",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Menu_Prof__Profi__31EC6D26",
                        column: x => x.ProfileId,
                        principalSchema: "Seg",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "Dim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_User",
                        column: x => x.UserCreator,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task_User",
                schema: "Fact",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_User", x => new { x.TaskId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Task_User_Task",
                        column: x => x.TaskId,
                        principalSchema: "Fact",
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_User_User",
                        column: x => x.UserId,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organization_User",
                schema: "Dim",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_User", x => new { x.OrganizationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Organization_User_Organization",
                        column: x => x.OrganizationId,
                        principalSchema: "Dim",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_User_User",
                        column: x => x.UserId,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Dim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Organization",
                        column: x => x.OrganizationId,
                        principalSchema: "Dim",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_State",
                        column: x => x.StateId,
                        principalSchema: "Mtro",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project_User",
                schema: "Dim",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_User", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Project_User_Project",
                        column: x => x.ProjectId,
                        principalSchema: "Dim",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_User",
                        column: x => x.UserId,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                schema: "Fact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(31)", unicode: false, maxLength: 31, nullable: true, computedColumnSql: "('T'+CONVERT([varchar],[id]))", stored: false),
                    Title = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    EstimatedDateEnded = table.Column<DateTime>(type: "datetime", nullable: false),
                    RealDateEnded = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserCreator = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Difficulty",
                        column: x => x.DifficultyId,
                        principalSchema: "Mtro",
                        principalTable: "Difficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Organization",
                        column: x => x.OrganizationId,
                        principalSchema: "Dim",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Priority",
                        column: x => x.PriorityId,
                        principalSchema: "Mtro",
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Project",
                        column: x => x.ProjectId,
                        principalSchema: "Dim",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_State",
                        column: x => x.StateId,
                        principalSchema: "Mtro",
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Type",
                        column: x => x.TypeId,
                        principalSchema: "Mtro",
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_User",
                        column: x => x.UserCreator,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Fact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Ticket",
                        column: x => x.TicketId,
                        principalSchema: "Fact",
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User",
                        column: x => x.UserId,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_User",
                schema: "Fact",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_User", x => new { x.TicketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Ticket_User_Ticket",
                        column: x => x.TicketId,
                        principalSchema: "Fact",
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_User_User",
                        column: x => x.UserId,
                        principalSchema: "Seg",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attached_ReferenceId",
                schema: "Fact",
                table: "Attached",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_StateId",
                schema: "Seg",
                table: "Menu",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Profile_ProfileId",
                schema: "Seg",
                table: "Menu_Profile",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_TicketId",
                schema: "Fact",
                table: "Message",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                schema: "Fact",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_UserCreator",
                schema: "Dim",
                table: "Organization",
                column: "UserCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_User_UserId",
                schema: "Dim",
                table: "Organization_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ_Name",
                schema: "Seg",
                table: "Profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                schema: "Dim",
                table: "Project",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_StateId",
                schema: "Dim",
                table: "Project",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_User_UserId",
                schema: "Dim",
                table: "Project_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_State_ReferenceId",
                schema: "Mtro",
                table: "State",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "UQ_Name1",
                schema: "Mtro",
                table: "State",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_User_UserId",
                schema: "Fact",
                table: "Task_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DifficultyId",
                schema: "Fact",
                table: "Ticket",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrganizationId",
                schema: "Fact",
                table: "Ticket",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PriorityId",
                schema: "Fact",
                table: "Ticket",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProjectId",
                schema: "Fact",
                table: "Ticket",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StateId",
                schema: "Fact",
                table: "Ticket",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TypeId",
                schema: "Fact",
                table: "Ticket",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserCreator",
                schema: "Fact",
                table: "Ticket",
                column: "UserCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_User_UserId",
                schema: "Fact",
                table: "Ticket_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                schema: "Seg",
                table: "User",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StateId",
                schema: "Seg",
                table: "User",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "UQ_Email",
                schema: "Seg",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attached",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Menu_Profile",
                schema: "Seg");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Organization_User",
                schema: "Dim");

            migrationBuilder.DropTable(
                name: "Project_User",
                schema: "Dim");

            migrationBuilder.DropTable(
                name: "Task_User",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Ticket_User",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Seg");

            migrationBuilder.DropTable(
                name: "Task",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Ticket",
                schema: "Fact");

            migrationBuilder.DropTable(
                name: "Difficulty",
                schema: "Mtro");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "Mtro");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Dim");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "Mtro");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "Dim");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Seg");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "Seg");

            migrationBuilder.DropTable(
                name: "State",
                schema: "Mtro");

            migrationBuilder.DropTable(
                name: "Reference",
                schema: "Mtro");
        }
    }
}
