using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManagement.Data.Migrations
{
    public partial class CreateRoomBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomBookings",
                columns: table => new
                {
                    RoomBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    toDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBookings", x => x.RoomBookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBookings");
        }
    }
}
