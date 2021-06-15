using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class MembershipReltion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_MembershipId",
                table: "Services",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_MembberShips_MembershipId",
                table: "Services",
                column: "MembershipId",
                principalTable: "MembberShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_MembberShips_MembershipId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_MembershipId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MemId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "Services");
        }
    }
}
