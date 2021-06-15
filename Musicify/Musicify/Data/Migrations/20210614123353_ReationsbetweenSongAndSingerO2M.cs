using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class ReationsbetweenSongAndSingerO2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SingerId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SingerId",
                table: "Songs",
                column: "SingerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Singers_SingerId",
                table: "Songs",
                column: "SingerId",
                principalTable: "Singers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Singers_SingerId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_SingerId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SingerId",
                table: "Songs");
        }
    }
}
