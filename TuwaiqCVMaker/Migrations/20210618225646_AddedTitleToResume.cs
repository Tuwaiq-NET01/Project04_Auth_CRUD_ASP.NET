using Microsoft.EntityFrameworkCore.Migrations;

namespace TuwaiqCVMaker.Migrations
{
    public partial class AddedTitleToResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Resumes");
        }
    }
}
