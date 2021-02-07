using Microsoft.EntityFrameworkCore.Migrations;

namespace CallLogger.Server.Data.Migrations
{
    public partial class ChangedUserOwnership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Calls",
                newName: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Calls",
                newName: "UserId");
        }
    }
}
