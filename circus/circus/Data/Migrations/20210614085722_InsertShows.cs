using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace circus.Data.Migrations
{
    public partial class InsertShows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "PerformerId", "VenueId" },
                values: new object[] { 1, new DateTime(2021, 6, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "PerformerId", "VenueId" },
                values: new object[] { 2, new DateTime(2021, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
