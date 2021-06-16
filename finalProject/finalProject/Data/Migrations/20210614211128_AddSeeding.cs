using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeeding : Migration
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

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "subject" },
                values: new object[,]
                {
                    { 1, "Dot Net" },
                    { 2, "React" },
                    { 3, "Design patterns" },
                    { 4, "Unit testing" }
                });

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

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "email", "name" },
                values: new object[,]
                {
                    { 1, "Afra@gmail.com", "Afra" },
                    { 2, "Norah@mail.com", "Norah" },
                    { 3, "taif@mail.com", "taif" },
                    { 4, "sara@mail.com", "sara" }
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

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
