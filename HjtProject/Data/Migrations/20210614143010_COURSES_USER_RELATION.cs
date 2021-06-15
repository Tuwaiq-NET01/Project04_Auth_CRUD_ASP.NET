using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class COURSES_USER_RELATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CourseId",
                table: "UserProfiles",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Courses_CourseId",
                table: "UserProfiles",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Courses_CourseId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CourseId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserProfiles");
        }
    }
}
