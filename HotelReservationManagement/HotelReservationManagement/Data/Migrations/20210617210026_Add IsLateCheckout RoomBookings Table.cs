using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManagement.Data.Migrations
{
    public partial class AddIsLateCheckoutRoomBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLateCheckout",
                table: "RoomBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLateCheckout",
                table: "RoomBookings");
        }
    }
}
