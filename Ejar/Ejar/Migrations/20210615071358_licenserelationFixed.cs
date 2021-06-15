using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejar.Migrations
{
    public partial class licenserelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_AspNetUsers_UserId",
                table: "License");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "License",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_License_UserId",
                table: "License",
                newName: "IX_License_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Account_AccountId",
                table: "License",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Account_AccountId",
                table: "License");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "License",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_License_AccountId",
                table: "License",
                newName: "IX_License_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_License_AspNetUsers_UserId",
                table: "License",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
