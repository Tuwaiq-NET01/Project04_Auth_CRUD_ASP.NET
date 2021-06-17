using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejar.Migrations
{
    public partial class AccountCompleteField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountComplete",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountComplete",
                table: "Account");
        }
    }
}
