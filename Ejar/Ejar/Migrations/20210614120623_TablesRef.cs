using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejar.Migrations
{
    public partial class TablesRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountModel_AspNetUsers_UserId",
                table: "AccountModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModel_Car_CarId",
                table: "ImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseModel_AspNetUsers_UserId",
                table: "LicenseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TripModel_AspNetUsers_UserId",
                table: "TripModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TripModel_Car_CarId",
                table: "TripModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripModel",
                table: "TripModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseModel",
                table: "LicenseModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountModel",
                table: "AccountModel");

            migrationBuilder.RenameTable(
                name: "TripModel",
                newName: "Trip");

            migrationBuilder.RenameTable(
                name: "LicenseModel",
                newName: "License");

            migrationBuilder.RenameTable(
                name: "ImageModel",
                newName: "Image");

            migrationBuilder.RenameTable(
                name: "AccountModel",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_TripModel_UserId",
                table: "Trip",
                newName: "IX_Trip_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TripModel_CarId",
                table: "Trip",
                newName: "IX_Trip_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseModel_UserId",
                table: "License",
                newName: "IX_License_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageModel_CarId",
                table: "Image",
                newName: "IX_Image_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountModel_UserId",
                table: "Account",
                newName: "IX_Account_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                table: "Trip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_License",
                table: "License",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_UserId",
                table: "Account",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Car_CarId",
                table: "Image",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_License_AspNetUsers_UserId",
                table: "License",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_AspNetUsers_UserId",
                table: "Trip",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Car_CarId",
                table: "Trip",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_UserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Car_CarId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_License_AspNetUsers_UserId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_AspNetUsers_UserId",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Car_CarId",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_License",
                table: "License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Trip",
                newName: "TripModel");

            migrationBuilder.RenameTable(
                name: "License",
                newName: "LicenseModel");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "ImageModel");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "AccountModel");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_UserId",
                table: "TripModel",
                newName: "IX_TripModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_CarId",
                table: "TripModel",
                newName: "IX_TripModel_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_License_UserId",
                table: "LicenseModel",
                newName: "IX_LicenseModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_CarId",
                table: "ImageModel",
                newName: "IX_ImageModel_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_UserId",
                table: "AccountModel",
                newName: "IX_AccountModel_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripModel",
                table: "TripModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseModel",
                table: "LicenseModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountModel",
                table: "AccountModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountModel_AspNetUsers_UserId",
                table: "AccountModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModel_Car_CarId",
                table: "ImageModel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseModel_AspNetUsers_UserId",
                table: "LicenseModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripModel_AspNetUsers_UserId",
                table: "TripModel",
                column: "UserId",
                principalTable: "AspNetUsers",
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
    }
}
