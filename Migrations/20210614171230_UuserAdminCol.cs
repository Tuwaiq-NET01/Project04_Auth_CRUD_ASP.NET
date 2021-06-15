using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Final.Migrations
{
    public partial class UuserAdminCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "User");
        }
    }
}
