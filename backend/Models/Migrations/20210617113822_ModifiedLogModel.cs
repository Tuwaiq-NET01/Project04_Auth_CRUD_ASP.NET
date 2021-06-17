using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Models.Migrations
{
    public partial class ModifiedLogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileSzie",
                table: "Logs",
                newName: "FileSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "Logs",
                newName: "FileSzie");
        }
    }
}
