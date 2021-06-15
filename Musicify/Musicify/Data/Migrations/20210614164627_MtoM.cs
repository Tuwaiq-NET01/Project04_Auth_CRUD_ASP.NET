using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class MtoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongModelId",
                table: "Favorites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_SongModelId",
                table: "Favorites",
                column: "SongModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Songs_SongModelId",
                table: "Favorites",
                column: "SongModelId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Songs_SongModelId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_SongModelId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "SongModelId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");
        }
    }
}
