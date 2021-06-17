using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class EditTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FanId",
                table: "CelebrityVideo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityVideo_FanId",
                table: "CelebrityVideo",
                column: "FanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityVideo_fans_FanId",
                table: "CelebrityVideo",
                column: "FanId",
                principalTable: "fans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityVideo_fans_FanId",
                table: "CelebrityVideo");

            migrationBuilder.DropIndex(
                name: "IX_CelebrityVideo_FanId",
                table: "CelebrityVideo");

            migrationBuilder.DropColumn(
                name: "FanId",
                table: "CelebrityVideo");
        }
    }
}
