using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddRelationsbtweenStudentAndFilesOneToManyAndbtweenCoursesAndFilesOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "course_id",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "Files");
        }
    }
}
