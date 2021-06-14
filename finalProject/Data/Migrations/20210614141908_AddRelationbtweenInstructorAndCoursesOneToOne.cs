using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddRelationbtweenInstructorAndCoursesOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "course_id",
                table: "Instructors");
        }
    }
}
