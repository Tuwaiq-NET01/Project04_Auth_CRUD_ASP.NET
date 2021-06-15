using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineSystem.Migrations
{
    public partial class TripsPlaneRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaneID",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaneNo",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_PlaneID",
                table: "Trips",
                column: "PlaneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Planes_PlaneID",
                table: "Trips",
                column: "PlaneID",
                principalTable: "Planes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Planes_PlaneID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_PlaneID",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PlaneID",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PlaneNo",
                table: "Trips");
        }
    }
}
