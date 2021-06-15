using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineSystem.Migrations
{
    public partial class AirportPlaneRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportID",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirportsAirportID",
                table: "Planes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planes_AirportsAirportID",
                table: "Planes",
                column: "AirportsAirportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Airports_AirportsAirportID",
                table: "Planes",
                column: "AirportsAirportID",
                principalTable: "Airports",
                principalColumn: "AirportID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Airports_AirportsAirportID",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_AirportsAirportID",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "AirportID",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "AirportsAirportID",
                table: "Planes");
        }
    }
}
