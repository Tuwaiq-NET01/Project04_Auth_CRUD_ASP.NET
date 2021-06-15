using Microsoft.EntityFrameworkCore.Migrations;

namespace Tchess.Migrations
{
    public partial class altertables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserIdId",
                table: "Profiles",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserIdId",
                table: "Profiles",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserIdId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserIdId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
