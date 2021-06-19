using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Project.Data.Migrations
{
    public partial class initialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStore_Book_Model",
                columns: table => new
                {
                    Book_ID = table.Column<int>(type: "int", nullable: false),
                    BookStore_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStore_Book_Model", x => new { x.BookStore_ID, x.Book_ID });
                    table.ForeignKey(
                        name: "FK_BookStore_Book_Model_Books_Book_ID",
                        column: x => x.Book_ID,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookStore_Book_Model_BookStores_BookStore_ID",
                        column: x => x.BookStore_ID,
                        principalTable: "BookStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Saud" },
                    { 2, "Sami" },
                    { 3, "Amira" }
                });

            migrationBuilder.InsertData(
                table: "BookStores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Store 1" },
                    { 2, "Store 2" },
                    { 3, "Store 3" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Publisher 1" },
                    { 2, "Publisher 2" },
                    { 3, "Publisher 3" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Image", "Name", "PublisherId" },
                values: new object[,]
                {
                    { 1, 1, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-11-300x300.png", "Saud Book 1", 1 },
                    { 5, 2, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-07-300x300.png", "Sami Book 1", 1 },
                    { 3, 3, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-05-300x300.png", "Amira Book 1", 2 },
                    { 6, 2, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-07-300x300.png", "Sami Book 2", 2 },
                    { 2, 1, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-11-300x300.png", "Saud Book 2", 3 },
                    { 4, 3, "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-05-300x300.png", "Amira Book 2", 3 }
                });

            migrationBuilder.InsertData(
                table: "BookStore_Book_Model",
                columns: new[] { "BookStore_ID", "Book_ID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 5 },
                    { 3, 3 },
                    { 1, 3 },
                    { 3, 6 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStore_Book_Model_Book_ID",
                table: "BookStore_Book_Model",
                column: "Book_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookStore_Book_Model");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookStores");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
