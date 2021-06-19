using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class remove_user_instructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_InstructorId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "UserProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_InstructorId",
                table: "UserProfiles",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Instructors_InstructorId",
                table: "UserProfiles",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
