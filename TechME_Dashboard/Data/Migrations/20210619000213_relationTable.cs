using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechME_Dashboard.Data.Migrations
{
    public partial class relationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Course_End_Date",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Course_Start_Date",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Instructor_ID",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TraineeCourses",
                columns: table => new
                {
                    Trainee_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    TraineeCourses_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourses", x => new { x.Course_ID, x.Trainee_ID });
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Course_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Course",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Trainee_Trainee_ID",
                        column: x => x.Trainee_ID,
                        principalTable: "Trainee",
                        principalColumn: "Trainee_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeInstructors",
                columns: table => new
                {
                    TraineeInstructor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trainee_ID = table.Column<int>(type: "int", nullable: false),
                    Instructor_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeInstructors", x => x.TraineeInstructor_ID);
                    table.ForeignKey(
                        name: "FK_TraineeInstructors_Instructor_Instructor_ID",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeInstructors_Trainee_Trainee_ID",
                        column: x => x.Trainee_ID,
                        principalTable: "Trainee",
                        principalColumn: "Trainee_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Instructor_ID",
                table: "Course",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourses_Trainee_ID",
                table: "TraineeCourses",
                column: "Trainee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeInstructors_Instructor_ID",
                table: "TraineeInstructors",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeInstructors_Trainee_ID",
                table: "TraineeInstructors",
                column: "Trainee_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_Instructor_ID",
                table: "Course",
                column: "Instructor_ID",
                principalTable: "Instructor",
                principalColumn: "Instructor_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_Instructor_ID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "TraineeCourses");

            migrationBuilder.DropTable(
                name: "TraineeInstructors");

            migrationBuilder.DropIndex(
                name: "IX_Course_Instructor_ID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Course_End_Date",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Course_Start_Date",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Instructor_ID",
                table: "Course");
        }
    }
}
