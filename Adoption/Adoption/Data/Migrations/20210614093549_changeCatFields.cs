using Microsoft.EntityFrameworkCore.Migrations;

namespace Adoption.Data.Migrations
{
    public partial class changeCatFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vaccination",
                table: "catTable");

            migrationBuilder.AddColumn<string>(
                name: "health",
                table: "catTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 1,
                column: "health",
                value: "Spayed / neutered.");

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 2,
                column: "health",
                value: "Spayed / neutered.");

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 3,
                column: "health",
                value: "Spayed / neutered.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "health",
                table: "catTable");

            migrationBuilder.AddColumn<bool>(
                name: "vaccination",
                table: "catTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 1,
                column: "vaccination",
                value: true);

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 2,
                column: "vaccination",
                value: true);

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 3,
                column: "vaccination",
                value: true);
        }
    }
}
