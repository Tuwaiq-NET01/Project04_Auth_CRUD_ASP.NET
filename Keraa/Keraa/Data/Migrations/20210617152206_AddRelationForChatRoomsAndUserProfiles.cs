using Microsoft.EntityFrameworkCore.Migrations;

namespace Keraa.Data.Migrations
{
    public partial class AddRelationForChatRoomsAndUserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherId",
                table: "ChatRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOwnerId",
                table: "ChatRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_OtherId",
                table: "ChatRooms",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_ProductOwnerId",
                table: "ChatRooms",
                column: "ProductOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_UserProfiles_OtherId",
                table: "ChatRooms",
                column: "OtherId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRooms_UserProfiles_ProductOwnerId",
                table: "ChatRooms",
                column: "ProductOwnerId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_UserProfiles_OtherId",
                table: "ChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRooms_UserProfiles_ProductOwnerId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_OtherId",
                table: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ChatRooms_ProductOwnerId",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "OtherId",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId",
                table: "ChatRooms");
        }
    }
}
