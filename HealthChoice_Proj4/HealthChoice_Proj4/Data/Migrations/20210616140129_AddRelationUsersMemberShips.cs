using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Proj4.Data.Migrations
{
    public partial class AddRelationUsersMemberShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipsModelId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipsModelId",
                table: "AspNetUsers",
                column: "MembershipsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MembberShips_MembershipsModelId",
                table: "AspNetUsers",
                column: "MembershipsModelId",
                principalTable: "MembberShips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MembberShips_MembershipsModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipsModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembershipID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembershipsModelId",
                table: "AspNetUsers");
        }
    }
}
