using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Migrations
{
    public partial class AddRelationProfileCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Profile_id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Profilesid",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Profilesid",
                table: "Courses",
                column: "Profilesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Profiles_Profilesid",
                table: "Courses",
                column: "Profilesid",
                principalTable: "Profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Profiles_Profilesid",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Profilesid",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Profile_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Profilesid",
                table: "Courses");
        }
    }
}
