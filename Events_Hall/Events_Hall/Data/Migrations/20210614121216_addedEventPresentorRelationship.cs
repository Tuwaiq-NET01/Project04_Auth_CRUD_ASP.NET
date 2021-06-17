using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class addedEventPresentorRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresentorId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_PresentorId",
                table: "Events",
                column: "PresentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Presentors_PresentorId",
                table: "Events",
                column: "PresentorId",
                principalTable: "Presentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Presentors_PresentorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PresentorId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PresentorId",
                table: "Events");
        }
    }
}
