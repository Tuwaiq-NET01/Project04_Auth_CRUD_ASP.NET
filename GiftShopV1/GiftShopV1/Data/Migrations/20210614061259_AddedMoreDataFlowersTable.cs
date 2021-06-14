using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShopV1.Data.Migrations
{
    public partial class AddedMoreDataFlowersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "FlowerId", "FlowerImage", "FlowerName", "FlowerPrice" },
                values: new object[,]
                {
                    { 11, "https://floward.imgix.net/web/Files/thumPro/637375823162633954.jpg?w=500", "Breeze", 322.00m },
                    { 12, "https://floward.imgix.net/web/Files/thumPro/637467433600235841.jpg?w=500", "Love Mix", 360.00m },
                    { 13, "https://floward.imgix.net/web/Files/thumPro/637368837979802520.jpg?width=600", "Sleek Bouquet", 200.00m },
                    { 14, "https://floward.imgix.net/web/Files/thumPro/637363759603959215.jpg?width=600", "35 Roses hand bouquet III", 280.00m },
                    { 15, "https://floward.imgix.net/web/Files/thumPro/637363761825283068.jpg?width=600", "50 Roses hand bouquet II", 414.00m },
                    { 16, "https://floward.imgix.net/web/Files/thumPro/637448274952847223.jpg?width=600", "White and Yellow Roses", 230.50m },
                    { 17, "https://floward.imgix.net/web/Files/thumPro/637503588358822359.jpg?width=600", "Pink Roses", 312.00m },
                    { 18, "https://floward.imgix.net/web/Files/thumPro/637502715042825399.jpg?width=600", "Purple Tulips", 430.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 18);
        }
    }
}
