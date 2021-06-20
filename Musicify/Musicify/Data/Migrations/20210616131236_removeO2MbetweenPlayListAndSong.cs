using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class removeO2MbetweenPlayListAndSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PlayLists_PlayListId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlayListId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayListId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlayListId",
                table: "Songs",
                column: "PlayListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PlayLists_PlayListId",
                table: "Songs",
                column: "PlayListId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
