using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeedingCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "id", "CommentContent", "CoursesModelid", "course_id" },
                values: new object[,]
                {
                    { 1, "First comment here ", null, 1 },
                    { 2, "second comment here ", null, 1 },
                    { 3, "third comment here ", null, 1 },
                    { 4, "First comment here ", null, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
