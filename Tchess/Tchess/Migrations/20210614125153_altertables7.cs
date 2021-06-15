using Microsoft.EntityFrameworkCore.Migrations;

namespace Tchess.Migrations
{
    public partial class altertables7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserIdId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Profiles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserIdId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profiles",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                newName: "IX_Profiles_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserIdId",
                table: "Profiles",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
