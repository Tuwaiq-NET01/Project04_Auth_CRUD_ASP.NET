using Microsoft.EntityFrameworkCore.Migrations;

namespace EzzRestaurant.Data.Migrations
{
    public partial class AddOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalPrice", "UserId" },
                values: new object[] { 1, 35.0, "c0186483-781b-44b9-b1ce-1f9e55e574bf" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalPrice", "UserId" },
                values: new object[] { 2, 156.0, "c0186483-781b-44b9-b1ce-1f9e55e574bf" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "TotalPrice", "UserId" },
                values: new object[] { 3, 21.0, "c0186483-781b-44b9-b1ce-1f9e55e574bf" });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 2, 1, 5 },
                    { 3, 2, 1 },
                    { 4, 2, 3 },
                    { 5, 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
