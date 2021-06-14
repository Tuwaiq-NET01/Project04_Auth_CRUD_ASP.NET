using Microsoft.EntityFrameworkCore.Migrations;

namespace circus.Data.Migrations
{
    public partial class AddShowVenueAndPerformerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PerformerId",
                table: "Shows",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_VenueId",
                table: "Shows",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Performers_PerformerId",
                table: "Shows",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Venues_VenueId",
                table: "Shows",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Performers_PerformerId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Venues_VenueId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_PerformerId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_VenueId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Shows");
        }
    }
}
