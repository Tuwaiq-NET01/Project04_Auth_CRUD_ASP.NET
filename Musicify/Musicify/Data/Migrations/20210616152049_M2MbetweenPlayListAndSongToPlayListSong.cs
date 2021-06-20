using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class M2MbetweenPlayListAndSongToPlayListSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayListId",
                table: "playListSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "playListSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_playListSongs_PlayListId",
                table: "playListSongs",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_playListSongs_SongId",
                table: "playListSongs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_playListSongs_PlayLists_PlayListId",
                table: "playListSongs",
                column: "PlayListId",
                principalTable: "PlayLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playListSongs_Songs_SongId",
                table: "playListSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playListSongs_PlayLists_PlayListId",
                table: "playListSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playListSongs_Songs_SongId",
                table: "playListSongs");

            migrationBuilder.DropIndex(
                name: "IX_playListSongs_PlayListId",
                table: "playListSongs");

            migrationBuilder.DropIndex(
                name: "IX_playListSongs_SongId",
                table: "playListSongs");

            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "playListSongs");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "playListSongs");
        }
    }
}
