using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Data.Migrations
{
    public partial class UserId5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Reservations",
                newName: "IDUser");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                newName: "IX_Reservations_IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_IDUser",
                table: "Reservations",
                column: "IDUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_IDUser",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "IDUser",
                table: "Reservations",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_IDUser",
                table: "Reservations",
                newName: "IX_Reservations_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
