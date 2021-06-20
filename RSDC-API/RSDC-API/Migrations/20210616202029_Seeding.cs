using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSDC_API.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "Image", "LastName", "Password", "Phone", "StartDate", "Username" },
                values: new object[] { 1, "Adel@KAlu", "Adel", "M", "http://adel-kalu.com/index/images/icon.png", "Kalu", "Adel@12345", 535555555, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AdelKalu" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "DivingType", "Fee" },
                values: new object[,]
                {
                    { 1, "Scuba Diving", 2500 },
                    { 2, "Free Diving", 2000 },
                    { 3, "Swimming", 1500 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CoachId", "Email", "FirstName", "Gender", "Image", "LastName", "Password", "Phone", "StartDate", "TypeId", "Username" },
                values: new object[] { 1, 1, "Ali@KAlu", "Ali", "M", "http://adel-kalu.com/index/images/icon.png", "Kalu", "Ali@12345", 535555555, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AliKalu" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Description", "Image", "Price", "Title", "TypeId" },
                values: new object[,]
                {
                    { 1, "SEAC Weight Belt Stainless Steel", "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", 45.5, "Belts", 1 },
                    { 2, "Aqualung Fusion Bullet Air", "https://www.scubastore.com/l/13737/137371573/aqualung-fusion-bullet-air.jpg", 4500.5, "Suit", 1 },
                    { 3, "Typhoon Quantum Lady", "https://www.scubastore.com/f/13796/137963780/typhoon-quantum-lady.jpg", 4000.0, "Suit", 2 },
                    { 4, "SEAC Weight Belt Stainless Steel", "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", 40.5, "Belts", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "MemberId", "TourName", "TourType", "Year" },
                values: new object[] { 1, 1, "800m free swimming", "Swimming", "2021" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
