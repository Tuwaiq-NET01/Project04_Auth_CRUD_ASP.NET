using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Proj4.Data.Migrations
{
    public partial class EventSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Image", "Location", "Name", "Overview" },
                values: new object[] { 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRW3B-BS2WusiV3saTLR6geS3arZRqonNxsBl4PrmunO34ndoXNNq_feMD3_ir62-6My-A&usqp=CAU", "Madinah", "Ezz Events", "Creative apps" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Image", "Location", "Name", "Overview" },
                values: new object[] { 2, new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9nRLwpIt897OeK8n3DCj7l1VCFEGtf2p8jU2fE0wgYLmfQ60KlY1SVYbMDwq96vv6tM&usqp=CAU", "Raif", "Samirah Events", "Creative apps" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
