using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class addedHallSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Avaliability", "Capacity", "Name" },
                values: new object[] { 1, true, 50, "First Venue" });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Avaliability", "Capacity", "Name" },
                values: new object[] { 2, false, 200, "Main Hall" });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Avaliability", "Capacity", "Name" },
                values: new object[] { 3, true, 1000, "Conference Hall " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
