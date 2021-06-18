using Microsoft.EntityFrameworkCore.Migrations;

namespace TechME_Dashboard.Data.Migrations
{
    public partial class created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Contact_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sender_Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Masssege_Subject = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sender_Massege = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Contact_ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Course_Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Course_Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Course_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Instructor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instructor_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Instructor_BIO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Instructor_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Instructor_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
