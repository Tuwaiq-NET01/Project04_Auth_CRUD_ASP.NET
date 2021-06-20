using Microsoft.EntityFrameworkCore.Migrations;

namespace RSDC_API.Migrations
{
    public partial class EditPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passward",
                table: "Members",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Passward",
                table: "Coaches",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Members",
                newName: "Passward");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Coaches",
                newName: "Passward");
        }
    }
}
