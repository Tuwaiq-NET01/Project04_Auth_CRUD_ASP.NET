using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class CreatingARelationshipCourseStudentV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesStudents_Courses_CourseModelId",
                table: "CoursesStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesStudents_Students_StudentModelId",
                table: "CoursesStudents");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CoursesStudents");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "CoursesStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentModelId",
                table: "CoursesStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseModelId",
                table: "CoursesStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesStudents_Courses_CourseModelId",
                table: "CoursesStudents",
                column: "CourseModelId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesStudents_Students_StudentModelId",
                table: "CoursesStudents",
                column: "StudentModelId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesStudents_Courses_CourseModelId",
                table: "CoursesStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesStudents_Students_StudentModelId",
                table: "CoursesStudents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentModelId",
                table: "CoursesStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseModelId",
                table: "CoursesStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CoursesStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "CoursesStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesStudents_Courses_CourseModelId",
                table: "CoursesStudents",
                column: "CourseModelId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesStudents_Students_StudentModelId",
                table: "CoursesStudents",
                column: "StudentModelId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
