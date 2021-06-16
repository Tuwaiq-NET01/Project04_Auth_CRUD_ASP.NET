using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeedingNumberThreeToFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "id", "CoursesModelid", "StudentModelid", "course_id", "date", "name", "student_id" },
                values: new object[,]
                {
                    { 1, null, null, 1, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 2, null, null, 1, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 3, null, null, 1, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 4, null, null, 1, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 5, null, null, 1, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
