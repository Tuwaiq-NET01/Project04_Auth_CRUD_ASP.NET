using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Data.Migrations
{
    public partial class CreateRoomStudentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StudentId",
                table: "Rooms",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Students_StudentId",
                table: "Rooms",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Students_StudentId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_StudentId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Rooms");
        }
    }
}
