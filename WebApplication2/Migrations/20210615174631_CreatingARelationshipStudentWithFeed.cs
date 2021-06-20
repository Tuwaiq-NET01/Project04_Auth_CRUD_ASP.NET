using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class CreatingARelationshipStudentWithFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Feeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_StudentId",
                table: "Feeds",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Students_StudentId",
                table: "Feeds",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Students_StudentId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_StudentId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Feeds");
        }
    }
}
