using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBookshelf.Data.Migrations
{
    public partial class alterBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "eBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "eBooks",
                type: "BLOB",
                nullable: true);
        }
    }
}
