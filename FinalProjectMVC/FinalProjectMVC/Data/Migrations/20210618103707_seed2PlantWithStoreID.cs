using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectMVC.Data.Migrations
{
    public partial class seed2PlantWithStoreID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1,
                column: "StoreId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2,
                column: "StoreId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 5,
                column: "StoreId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6,
                column: "StoreId",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 8,
                column: "StoreId",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 9,
                column: "StoreId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 10,
                column: "StoreId",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 11,
                column: "StoreId",
                value: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 5,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 8,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 9,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 10,
                column: "StoreId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 11,
                column: "StoreId",
                value: 0);
        }
    }
}
