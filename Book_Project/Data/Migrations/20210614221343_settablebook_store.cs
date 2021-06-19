using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Project.Data.Migrations
{
    public partial class settablebook_store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStore_Book_Model_Books_Book_ID",
                table: "BookStore_Book_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStore_Book_Model_BookStores_BookStore_ID",
                table: "BookStore_Book_Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStore_Book_Model",
                table: "BookStore_Book_Model");

            migrationBuilder.RenameTable(
                name: "BookStore_Book_Model",
                newName: "BookStores_Books");

            migrationBuilder.RenameIndex(
                name: "IX_BookStore_Book_Model_Book_ID",
                table: "BookStores_Books",
                newName: "IX_BookStores_Books_Book_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStores_Books",
                table: "BookStores_Books",
                columns: new[] { "BookStore_ID", "Book_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_Books_Books_Book_ID",
                table: "BookStores_Books",
                column: "Book_ID",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_Books_BookStores_BookStore_ID",
                table: "BookStores_Books",
                column: "BookStore_ID",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_Books_Books_Book_ID",
                table: "BookStores_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_Books_BookStores_BookStore_ID",
                table: "BookStores_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStores_Books",
                table: "BookStores_Books");

            migrationBuilder.RenameTable(
                name: "BookStores_Books",
                newName: "BookStore_Book_Model");

            migrationBuilder.RenameIndex(
                name: "IX_BookStores_Books_Book_ID",
                table: "BookStore_Book_Model",
                newName: "IX_BookStore_Book_Model_Book_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStore_Book_Model",
                table: "BookStore_Book_Model",
                columns: new[] { "BookStore_ID", "Book_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookStore_Book_Model_Books_Book_ID",
                table: "BookStore_Book_Model",
                column: "Book_ID",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStore_Book_Model_BookStores_BookStore_ID",
                table: "BookStore_Book_Model",
                column: "BookStore_ID",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
