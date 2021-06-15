using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class UserProfile_Relations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CourseId",
                table: "UserProfiles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_InstructorId",
                table: "UserProfiles",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Courses_CourseId",
                table: "UserProfiles",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorId",
                table: "UserProfiles",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Courses_CourseId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CourseId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_InstructorId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "UserProfiles");
        }
    }
}
