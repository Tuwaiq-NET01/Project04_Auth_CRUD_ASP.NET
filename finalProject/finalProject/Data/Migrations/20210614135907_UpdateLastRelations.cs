using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class UpdateLastRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesModelid",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentModelid",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CoursesModelid",
                table: "Files",
                column: "CoursesModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentModelid",
                table: "Files",
                column: "StudentModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CoursesModelid",
                table: "Files",
                column: "CoursesModelid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Students_StudentModelid",
                table: "Files",
                column: "StudentModelid",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CoursesModelid",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Students_StudentModelid",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CoursesModelid",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_StudentModelid",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CoursesModelid",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "StudentModelid",
                table: "Files");
        }
    }
}
