using Microsoft.EntityFrameworkCore.Migrations;

namespace Keraa.Data.Migrations
{
    public partial class AddRelationForUserProfilesAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerId",
                table: "Products",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TenantId",
                table: "Products",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserProfiles_OwnerId",
                table: "Products",
                column: "OwnerId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserProfiles_TenantId",
                table: "Products",
                column: "TenantId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserProfiles_OwnerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserProfiles_TenantId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TenantId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Products");
        }
    }
}
