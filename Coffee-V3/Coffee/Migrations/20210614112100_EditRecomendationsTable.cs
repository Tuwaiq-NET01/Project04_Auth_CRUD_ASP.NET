using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class EditRecomendationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailabilityLoc",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabilityLoc",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Recommendations");
        }
    }
}
