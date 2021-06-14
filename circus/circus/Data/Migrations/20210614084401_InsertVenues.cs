using Microsoft.EntityFrameworkCore.Migrations;

namespace circus.Data.Migrations
{
    public partial class InsertVenues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Image", "Name", "Type" },
                values: new object[] { 1, "Las Vegas, NV", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/07/be/34/8d/treasure-island-ti-hotel.jpg?w=900&h=-1&s=1", "Treasure Island", "Casino" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Image", "Name", "Type" },
                values: new object[] { 2, "Las Vegas, NV", "https://media-cdn.tripadvisor.com/media/photo-s/1c/8a/e0/b9/bellagio-las-vegas.jpg", "Bellagio", "Casino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
