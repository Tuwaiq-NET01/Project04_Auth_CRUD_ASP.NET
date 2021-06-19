using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Migrations
{
    public partial class AddRelationProfileCourses3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfileId",
                table: "Courses",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Profiles_ProfileId",
                table: "Courses",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Profiles_ProfileId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ProfileId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Courses");
        }
    }
}
