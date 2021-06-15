using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineSystem.Migrations
{
    public partial class PassengersTripRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripNo",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripNo1",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_TripNo1",
                table: "Passengers",
                column: "TripNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Trips_TripNo1",
                table: "Passengers",
                column: "TripNo1",
                principalTable: "Trips",
                principalColumn: "TripNo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Trips_TripNo1",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_TripNo1",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TripNo",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TripNo1",
                table: "Passengers");
        }
    }
}
