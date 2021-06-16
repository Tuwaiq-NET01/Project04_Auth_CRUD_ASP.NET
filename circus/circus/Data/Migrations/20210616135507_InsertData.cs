using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace circus.Data.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Image", "Name", "Profession" },
                values: new object[,]
                {
                    { 3, "https://www.cirquedusoleil.com/-/media/cds/images/shows/joya/highlights/joya_highlights_03_botanik_480x480_2.jpg?db=web&h=480&la=en&vs=1&w=480&hash=80B381B61B5B00159C5B279A50242E1B59DF5EF7", "Joyà", "Performing arts" },
                    { 4, "https://www.cirquedusoleil.com/-/media/cds/images/shows/crystal/hightlights/thumb/crystal_highlights_01_480x480.jpg?db=web&h=480&la=en&vs=1&w=480&hash=9A360571B39D365B743A539F3F902E57C451122C", "Crystal", "Acrobatics on ice" },
                    { 5, "https://www.cirquedusoleil.com/-/media/cds/images/shows/kurios/highlights_thumbnail/kurios-show-rola-bola.jpg?db=web&h=480&la=en&vs=1&w=480&hash=4E130ABB3F44E29C31D643003A976D77F4098C6A", "KURIOS", "Act" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Image", "Name", "Type" },
                values: new object[,]
                {
                    { 3, "Riviera Maya, Mexico", "https://i.pinimg.com/originals/c0/dd/f7/c0ddf756d6663523acc138503b23840c.jpg", "Cirque du Soleil", "Theater" },
                    { 4, "Hanover, Germany", "https://www.hannover.de/var/storage/images/media/01-data-neu/bilder/redaktion-hannover.de/portale/b%C3%BChnen/tui-arena/7060009-1-ger-DE/TUI-Arena.jpg", "ZAG", "Arena" },
                    { 5, "Rome, Italy", "https://www.eventiculturalimagazine.com/wp-content/uploads/2018/12/mio-20.jpg", "Tor di Quinto", "Tent" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "PerformerId", "VenueId" },
                values: new object[] { 3, new DateTime(2021, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "PerformerId", "VenueId" },
                values: new object[] { 4, new DateTime(2021, 9, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Date", "PerformerId", "VenueId" },
                values: new object[] { 5, new DateTime(2022, 4, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
