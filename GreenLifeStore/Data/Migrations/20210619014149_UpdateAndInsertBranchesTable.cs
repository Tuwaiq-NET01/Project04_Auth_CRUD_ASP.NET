using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class UpdateAndInsertBranchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                columns: new[] { "Address", "City", "Email", "Mobile", "Telephone" },
                values: new object[] { "Takhassusi Street, Al Nakheel District", "Riyadh", "info@GreenLife.com", "0507076701", "011 629 4056" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2,
                columns: new[] { "Address", "City", "Email", "Mobile", "Telephone" },
                values: new object[] { "Omar ibn Al Khattab Street, Al Faisaliyah District", "Dammam", "info@GreenLife.com", "0557889843", "013 634 4742" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3,
                columns: new[] { "Address", "City", "Email", "Mobile", "Telephone" },
                values: new object[] { "Abdullah Al Khayl Street, Al Khalidiyyah District", "Jeddah", "info@GreenLife.com", "0567584822", "012 645 4344" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 4, 41, 48, 871, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 4, 41, 48, 872, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 4, 41, 48, 872, DateTimeKind.Local).AddTicks(9940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Branches");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                column: "Address",
                value: "Riyadh");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2,
                column: "Address",
                value: "Dammam");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3,
                column: "Address",
                value: "Jeddah");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 2, 1, 8, 434, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 2, 1, 8, 436, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 2, 1, 8, 436, DateTimeKind.Local).AddTicks(810));
        }
    }
}
