using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddFavoriteDropTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_AspNetUsers_ApplicationUserId",
                table: "MyProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Drops_DropId",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "FavoriteDrops");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_ApplicationUserId",
                table: "FavoriteDrops",
                newName: "IX_FavoriteDrops_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteDrops",
                table: "FavoriteDrops",
                columns: new[] { "DropId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDrops_AspNetUsers_ApplicationUserId",
                table: "FavoriteDrops",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDrops_Drops_DropId",
                table: "FavoriteDrops",
                column: "DropId",
                principalTable: "Drops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDrops_AspNetUsers_ApplicationUserId",
                table: "FavoriteDrops");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDrops_Drops_DropId",
                table: "FavoriteDrops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteDrops",
                table: "FavoriteDrops");

            migrationBuilder.RenameTable(
                name: "FavoriteDrops",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteDrops_ApplicationUserId",
                table: "MyProperty",
                newName: "IX_MyProperty_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                columns: new[] { "DropId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_AspNetUsers_ApplicationUserId",
                table: "MyProperty",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Drops_DropId",
                table: "MyProperty",
                column: "DropId",
                principalTable: "Drops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
