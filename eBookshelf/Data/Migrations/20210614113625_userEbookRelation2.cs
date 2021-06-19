using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookshelf.Data.Migrations
{
    public partial class userEbookRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "eBooks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_eBooks_OwnerId",
                table: "eBooks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_eBooks_AspNetUsers_OwnerId",
                table: "eBooks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eBooks_AspNetUsers_OwnerId",
                table: "eBooks");

            migrationBuilder.DropIndex(
                name: "IX_eBooks_OwnerId",
                table: "eBooks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "eBooks");
        }
    }
}
