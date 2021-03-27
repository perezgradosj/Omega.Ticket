using Microsoft.EntityFrameworkCore.Migrations;

namespace Omega.Ticket.Infraestructure.Data.Migrations
{
    public partial class JP_AddUniqueToPhone_UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_Phone",
                schema: "Seg",
                table: "User",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Phone",
                schema: "Seg",
                table: "User");
        }
    }
}
