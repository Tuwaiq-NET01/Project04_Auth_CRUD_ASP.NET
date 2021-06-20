using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class InserIntoBranchProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BranchProduct",
                columns: new[] { "BranchId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 3 },
                    { 3, 2 },
                    { 3, 1 },
                    { 3, 10 },
                    { 3, 9 },
                    { 2, 8 },
                    { 2, 1 },
                    { 2, 6 },
                    { 2, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 2, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 1, 58, 41, 105, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 1, 58, 41, 107, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 1, 58, 41, 107, DateTimeKind.Local).AddTicks(4141));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "BranchProduct",
                keyColumns: new[] { "BranchId", "ProductId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 0, 46, 48, 802, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 0, 46, 48, 804, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 19, 0, 46, 48, 804, DateTimeKind.Local).AddTicks(1455));
        }
    }
}
