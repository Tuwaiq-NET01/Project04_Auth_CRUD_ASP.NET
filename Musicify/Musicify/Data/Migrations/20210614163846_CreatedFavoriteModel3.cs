using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class CreatedFavoriteModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Songs_SongId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_SongId",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "SongModelId",
                table: "Favorites",
                type: "int",
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
                name: "SongModelId",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_SongId",
                table: "Favorites",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Songs_SongId",
                table: "Favorites",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
