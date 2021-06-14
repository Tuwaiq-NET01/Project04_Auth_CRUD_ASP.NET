using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class COURSES_INS_RELATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstructorId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_InstructorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Course");
        }
    }
}
