using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceRoomManager.Data.Migrations
{
    public partial class AddUserNameToBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bookings");
        }
    }
}
