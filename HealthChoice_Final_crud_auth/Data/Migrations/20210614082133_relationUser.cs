using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class relationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MembberShips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembberShips_UserId",
                table: "MembberShips",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MembberShips_AspNetUsers_UserId",
                table: "MembberShips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembberShips_AspNetUsers_UserId",
                table: "MembberShips");

            migrationBuilder.DropIndex(
                name: "IX_MembberShips_UserId",
                table: "MembberShips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MembberShips");
        }
    }
}
