using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeedingNumberTowToFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "id", "CoursesModelid", "StudentModelid", "course_id", "date", "name", "student_id" },
                values: new object[,]
                {
                    { 6, null, null, 2, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 7, null, null, 2, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 8, null, null, 2, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 9, null, null, 2, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 10, null, null, 2, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 11, null, null, 3, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 12, null, null, 3, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 13, null, null, 3, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 14, null, null, 3, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 15, null, null, 3, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 16, null, null, 4, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 17, null, null, 4, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 18, null, null, 4, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 19, null, null, 4, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 20, null, null, 4, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "id",
                keyValue: 20);

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
                table: "Files",
                columns: new[] { "id", "CoursesModelid", "StudentModelid", "course_id", "date", "name", "student_id" },
                values: new object[,]
                {
                    { 5, null, null, 1, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 4, null, null, 1, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 3, null, null, 1, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 2, null, null, 1, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 1, null, null, 1, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 }
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
    }
}
