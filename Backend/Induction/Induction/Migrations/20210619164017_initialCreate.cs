using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Induction.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motivations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Motivations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterChunks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentPage = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterChunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterChunks_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "C# in Depth, Fourth Edition", "https://www.oreilly.com/library/view/c-in-depth/9781617294532/" },
                    { 2, "Head First C#, 4th Editio", "https://www.oreilly.com/library/view/head-first-c/9781491976692/" }
                });

            migrationBuilder.InsertData(
                table: "FlashCards",
                columns: new[] { "id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class. ", "What is an abstract Keyword?" },
                    { 2, "A delegate is a reference type that can be used to encapsulate a named or an anonymous method.", "Delegate " }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Body" },
                values: new object[,]
                {
                    { 1, "Stay Focused" },
                    { 2, "Keep it going" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Mansoviic@gmail.com", "Mansovic", "P@assWord123" },
                    { 2, "Mansoviic2@gmail.com", "Mansovic2", "P@assWord1232" }
                });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "BookId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Introduction" },
                    { 2, 1, "Deep Coding" }
                });

            migrationBuilder.InsertData(
                table: "Facts",
                columns: new[] { "Id", "Attachment", "Body", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 2, "https://edu.rsc.org/resources/tyndall-effect-why-the-sky-is-blue/1877.article", "Tyndall effect- why the sky is blue", new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(2378), 1 },
                    { 1, "https://www.w3schools.com/cs/cs_oop.asp", "C# is OOP", new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(1576), 2 }
                });

            migrationBuilder.InsertData(
                table: "Motivations",
                columns: new[] { "id", "Body", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 2, "If you really want the key to success, start by doing the opposite of what everyone else is doing. —Brad Szollose", new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(74), 1 },
                    { 1, "Too many of us are not living our dreams because we are living our fears. —Les Brown", new DateTime(2021, 6, 19, 16, 40, 16, 678, DateTimeKind.Utc).AddTicks(9179), 2 }
                });

            migrationBuilder.InsertData(
                table: "ChapterChunks",
                columns: new[] { "Id", "Body", "ChapterId", "CreatedAt", "CurrentPage", "Title" },
                values: new object[] { 2, "a small intro ", 1, new DateTime(2021, 6, 19, 16, 40, 16, 680, DateTimeKind.Utc).AddTicks(956), 12, "intro" });

            migrationBuilder.InsertData(
                table: "ChapterChunks",
                columns: new[] { "Id", "Body", "ChapterId", "CreatedAt", "CurrentPage", "Title" },
                values: new object[] { 1, "what is deep coding and why", 2, new DateTime(2021, 6, 19, 16, 40, 16, 680, DateTimeKind.Utc).AddTicks(154), 23, "Deep Coding" });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterChunks_ChapterId",
                table: "ChapterChunks",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BookId",
                table: "Chapters",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_UserId",
                table: "Facts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivations_UserId",
                table: "Motivations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterChunks");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Motivations");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
