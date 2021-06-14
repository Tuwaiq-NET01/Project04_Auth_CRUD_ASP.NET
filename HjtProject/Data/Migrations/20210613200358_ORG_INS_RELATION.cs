using Microsoft.EntityFrameworkCore.Migrations;

namespace HjtProject.Data.Migrations
{
    public partial class ORG_INS_RELATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_OrganizationId",
                table: "Instructor",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Organization_OrganizationId",
                table: "Instructor",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Organization_OrganizationId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_OrganizationId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Instructor");
        }
    }
}
