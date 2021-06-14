using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class deleteRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Services_ServicesservId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_MembberShips_AspNetUsers_UserId",
                table: "MembberShips");

            migrationBuilder.DropIndex(
                name: "IX_MembberShips_UserId",
                table: "MembberShips");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServicesservId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MembberShips");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServicesservId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MembberShips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesservId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembberShips_UserId",
                table: "MembberShips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServicesservId",
                table: "Comments",
                column: "ServicesservId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Services_ServicesservId",
                table: "Comments",
                column: "ServicesservId",
                principalTable: "Services",
                principalColumn: "servId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembberShips_AspNetUsers_UserId",
                table: "MembberShips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
