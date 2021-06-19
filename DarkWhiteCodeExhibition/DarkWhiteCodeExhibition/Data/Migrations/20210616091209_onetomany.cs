using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkWhiteCodeExhibition.Data.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "ArtPiecesModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtPiecesModel_ApplicationUserID",
                table: "ArtPiecesModel",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPiecesModel_AspNetUsers_ApplicationUserID",
                table: "ArtPiecesModel",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPiecesModel_AspNetUsers_ApplicationUserID",
                table: "ArtPiecesModel");

            migrationBuilder.DropIndex(
                name: "IX_ArtPiecesModel_ApplicationUserID",
                table: "ArtPiecesModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "ArtPiecesModel");
        }
    }
}
