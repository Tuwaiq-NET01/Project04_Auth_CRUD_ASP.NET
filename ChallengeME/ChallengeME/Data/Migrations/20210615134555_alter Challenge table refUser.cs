using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeME.Data.Migrations
{
    public partial class alterChallengetablerefUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Challenges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_UserId",
                table: "Challenges",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_AspNetUsers_UserId",
                table: "Challenges",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_AspNetUsers_UserId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_UserId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Challenges");
        }
    }
}
