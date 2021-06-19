using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CoursesModelid",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Students_StudentModelid",
                table: "Files");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Students");

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

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_course_id",
                table: "Instructors",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_course_id",
                table: "Files",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_course_id",
                table: "Files",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_course_id",
                table: "Instructors",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_course_id",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_course_id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_course_id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Files_course_id",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "path",
                table: "Files");

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

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoursesModelid = table.Column<int>(type: "int", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Courses_CoursesModelid",
                        column: x => x.CoursesModelid,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

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

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 1,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 2,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 3,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 4,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 5,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 6,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 7,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 8,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 9,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 10,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 11,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 12,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 13,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 14,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 15,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 16,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 17,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 18,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 19,
                column: "student_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 20,
                column: "student_id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "email", "name" },
                values: new object[,]
                {
                    { 1, "Afra@gmail.com", "Afra" },
                    { 2, "Norah@mail.com", "Norah" },
                    { 4, "sara@mail.com", "sara" },
                    { 3, "taif@mail.com", "taif" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_CoursesModelid",
                table: "Files",
                column: "CoursesModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentModelid",
                table: "Files",
                column: "StudentModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CoursesModelid",
                table: "Comments",
                column: "CoursesModelid");

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
    }
}
