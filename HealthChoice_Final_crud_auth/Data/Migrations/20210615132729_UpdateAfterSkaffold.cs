using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class UpdateAfterSkaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "memName",
                table: "MembberShips",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "memBenefits",
                table: "MembberShips",
                newName: "Benefits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MembberShips",
                newName: "memName");

            migrationBuilder.RenameColumn(
                name: "Benefits",
                table: "MembberShips",
                newName: "memBenefits");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
