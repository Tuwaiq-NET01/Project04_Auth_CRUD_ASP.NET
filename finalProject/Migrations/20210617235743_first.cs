using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    CoursesModelid = table.Column<int>(type: "int", nullable: true)
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
                name: "Information",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.id);
                    table.ForeignKey(
                        name: "FK_Information_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    CoursesModelid = table.Column<int>(type: "int", nullable: true),
                    StudentModelid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                    table.ForeignKey(
                        name: "FK_Files_Courses_CoursesModelid",
                        column: x => x.CoursesModelid,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Students_StudentModelid",
                        column: x => x.StudentModelid,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 13, null, null, 3, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 14, null, null, 3, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 15, null, null, 3, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 16, null, null, 4, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 20, null, null, 4, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 18, null, null, 4, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 19, null, null, 4, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 12, null, null, 3, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 17, null, null, 4, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 11, null, null, 3, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 10, null, null, 2, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 },
                    { 9, null, null, 2, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 2, null, null, 1, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 3, null, null, 1, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 4, null, null, 1, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture four week 4", 1 },
                    { 1, null, null, 1, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 6, null, null, 2, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture One week 4", 1 },
                    { 7, null, null, 2, new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture tow week 4", 1 },
                    { 8, null, null, 2, new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture three week 4", 1 },
                    { 5, null, null, 1, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lecture five week 4", 1 }
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
                    { 3, "taif@mail.com", "taif" },
                    { 1, "Afra@gmail.com", "Afra" },
                    { 2, "Norah@mail.com", "Norah" },
                    { 4, "sara@mail.com", "sara" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CoursesModelid",
                table: "Comments",
                column: "CoursesModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CoursesModelid",
                table: "Files",
                column: "CoursesModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentModelid",
                table: "Files",
                column: "StudentModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Information_course_id",
                table: "Information",
                column: "course_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
