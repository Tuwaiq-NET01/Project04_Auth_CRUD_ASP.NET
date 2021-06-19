using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Migrations
{
    public partial class updateimgColmnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "img",
                table: "Courses",
                newName: "imgUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "Courses",
                newName: "img");
        }
    }
}
