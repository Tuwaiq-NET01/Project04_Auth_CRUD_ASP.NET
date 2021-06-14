using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejar.Migrations
{
    public partial class CarTableRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_AspNetUsers_UserId",
                table: "CarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_Location_LocationId",
                table: "CarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModel_CarModel_CarId",
                table: "ImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TripModel_CarModel_CarId",
                table: "TripModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_UserId",
                table: "Car",
                newName: "IX_Car_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_LocationId",
                table: "Car",
                newName: "IX_Car_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_AspNetUsers_UserId",
                table: "Car",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Location_LocationId",
                table: "Car",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModel_Car_CarId",
                table: "ImageModel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripModel_Car_CarId",
                table: "TripModel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_AspNetUsers_UserId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Location_LocationId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModel_Car_CarId",
                table: "ImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TripModel_Car_CarId",
                table: "TripModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "CarModel");

            migrationBuilder.RenameIndex(
                name: "IX_Car_UserId",
                table: "CarModel",
                newName: "IX_CarModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_LocationId",
                table: "CarModel",
                newName: "IX_CarModel_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_AspNetUsers_UserId",
                table: "CarModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_Location_LocationId",
                table: "CarModel",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModel_CarModel_CarId",
                table: "ImageModel",
                column: "CarId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripModel_CarModel_CarId",
                table: "TripModel",
                column: "CarId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
