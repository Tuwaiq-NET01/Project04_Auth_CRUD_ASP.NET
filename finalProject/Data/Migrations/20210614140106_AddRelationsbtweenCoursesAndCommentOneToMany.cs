using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddRelationsbtweenCoursesAndCommentOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesModelid",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CoursesModelid",
                table: "Comments",
                column: "CoursesModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Courses_CoursesModelid",
                table: "Comments",
                column: "CoursesModelid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Courses_CoursesModelid",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CoursesModelid",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CoursesModelid",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "course_id",
                table: "Comments");
        }
    }
}
