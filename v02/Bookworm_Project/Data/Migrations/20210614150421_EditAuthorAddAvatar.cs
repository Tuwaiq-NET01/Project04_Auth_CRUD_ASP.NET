using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookworm_Project.Data.Migrations
{
    public partial class EditAuthorAddAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Authors");
        }
    }
}
