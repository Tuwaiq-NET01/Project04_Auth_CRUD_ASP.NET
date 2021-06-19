using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookshelf.Data.Migrations
{
    public partial class noteEBookRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EbookId",
                table: "Notes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ebook_id",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageNo",
                table: "Notes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EbookId",
                table: "Notes",
                column: "EbookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_eBooks_EbookId",
                table: "Notes",
                column: "EbookId",
                principalTable: "eBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_eBooks_EbookId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_EbookId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "EbookId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Ebook_id",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "PageNo",
                table: "Notes");
        }
    }
}
