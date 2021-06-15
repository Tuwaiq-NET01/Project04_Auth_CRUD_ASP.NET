using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class Instructor_USER_RELATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorModelId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "InstructorModelId",
                table: "UserProfiles",
                newName: "InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_InstructorModelId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_InstructorId");

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
                name: "FK_UserProfiles_Instructors_InstructorId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "UserProfiles",
                newName: "InstructorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_InstructorId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_InstructorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorModelId",
                table: "UserProfiles",
                column: "InstructorModelId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
