using Microsoft.EntityFrameworkCore.Migrations;

namespace Omega.Ticket.Infraestructure.Data.Migrations
{
    public partial class JP_AddUniqueToEmail_UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Email",
                schema: "Seg",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "UQ_Email",
                schema: "Seg",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Email",
                schema: "Seg",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "UQ_Email",
                schema: "Seg",
                table: "User",
                column: "Id",
                unique: true);
        }
    }
}
