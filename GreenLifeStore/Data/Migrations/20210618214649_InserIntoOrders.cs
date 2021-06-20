using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class InserIntoOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "TotalPrice", "UserId" },
                values: new object[] { 1, new DateTime(2021, 6, 19, 0, 46, 48, 802, DateTimeKind.Local).AddTicks(8966), 236.5f, "12e2ec6e-45f1-4ac4-bcec-6aca5cd56456" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "TotalPrice", "UserId" },
                values: new object[] { 2, new DateTime(2021, 6, 19, 0, 46, 48, 804, DateTimeKind.Local).AddTicks(1405), 216.5f, "9846fc6d-733e-4f26-90f6-0599199363be" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "TotalPrice", "UserId" },
                values: new object[] { 3, new DateTime(2021, 6, 19, 0, 46, 48, 804, DateTimeKind.Local).AddTicks(1455), 67f, "bb091c98-1b17-4907-bcae-5eb8141f6195" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);
        }
    }
}
