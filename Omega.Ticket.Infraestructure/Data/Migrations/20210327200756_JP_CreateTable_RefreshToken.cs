using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Omega.Ticket.Infraestructure.Data.Migrations
{
    public partial class JP_CreateTable_RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "Seg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Token = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "Seg");
        }
    }
}
