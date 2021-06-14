using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeedingToInstructorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "id", "course_id", "email", "name" },
                values: new object[,]
                {
                    { 1, 1, "sami@gmail.com", "sami" },
                    { 2, 1, "ghada@gmail.com", "ghada" },
                    { 3, 2, "lamyaa@gmail.com", "lamyaa" },
                    { 4, 4, "fai@gmail.com", "fai" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
