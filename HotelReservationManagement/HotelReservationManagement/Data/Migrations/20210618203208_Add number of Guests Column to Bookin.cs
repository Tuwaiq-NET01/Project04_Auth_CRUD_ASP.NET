using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManagement.Data.Migrations
{
    public partial class AddnumberofGuestsColumntoBookin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "RoomBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "RoomBookings");
        }
    }
}
