using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectMVC.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlantCares",
                columns: new[] { "PlantCareId", "irrigation", "light", "plantId", "temperature" },
                values: new object[,]
                {
                    { 110, "Twice", "Yes", 0, 20.0 },
                    { 210, "Once", "Yes", 0, 25.0 }
                });

            migrationBuilder.InsertData(
                table: "PlantStores",
                columns: new[] { "StoreId", "StoreEmail", "StoreLocation", "StoreName", "StorePhoneNo" },
                values: new object[,]
                {
                    { 100, "PR@mail.com", "Riyadh", "Plant Store", "011188374" },
                    { 200, "PJ@mail.com", "Jeddah", "Plant Store", "014883" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Id", "Image", "PlantColor", "PlantHeight", "PlantName", "PlantStoreStoreId", "PlantType", "Price", "StoreId" },
                values: new object[,]
                {
                    { 1, null, "https://www.nabataty.com/store/wp-content/uploads/2021/04/2837.jpg", "green", 40, "Rosemary", null, "indoor plants", 200.0, 0 },
                    { 2, null, "https://www.nabataty.com/store/wp-content/uploads/2021/05/2944.jpg", "green with purple", 60, "Clathia Flame", null, "indoor plants", 300.0, 0 },
                    { 3, null, "https://cdn.salla.sa/AApPZ/IfXTx6DhLUQHg6T4bF2C1xyegeJCKH5eQTMkG2Rl.jpg", "yellow", 30, "Roses", null, "indoor plants", 40.0, 0 },
                    { 4, null, "https://www.nabataty.com/store/wp-content/uploads/2020/10/1519.jpg", "pink", 60, "Kaluna", null, "outdoor plants", 100.0, 0 },
                    { 5, null, "https://d1aqy00qjeidmk.cloudfront.net/upload/product/product1-1605788685.jpg", "green with yellow", 50, "Bird of Paradise", null, "outdoor plants", 200.0, 0 },
                    { 6, null, "https://static.wixstatic.com/media/a27d24_1415dbffce734563a41e5859a507dc82~mv2.jpg/v1/fill/w_1000,h_1274,al_c,q_90,usm_0.66_1.00_0.01/a27d24_1415dbffce734563a41e5859a507dc82~mv2.jpg", "green", 70, "Chilevera", null, "indoor plants", 150.0, 0 },
                    { 7, null, "https://www.nabataty.com/store/wp-content/uploads/2020/06/982.jpg", "green", 120, "Olive Tree", null, "outdoor plants", 80.0, 0 },
                    { 8, null, "https://media.zid.store/thumbs/c9146352-5f34-4d3a-8115-22631018afb2/e19a1dca-ecd5-497b-8c1d-7bf6321a1d8a-thumbnail-370x370.png", "green with purple", 30, "Basil", null, "in/out/door plants", 40.0, 0 },
                    { 9, null, "https://qtrees.com/wp-content/uploads/2020/10/unnamed.jpg", "green", 20, "Fix", null, "in/out/door plants", 100.0, 0 },
                    { 10, null, "https://www.nabataty.com/store/wp-content/uploads/2021/01/1910-A.jpg", "green with red", 40, "Newreglia", null, "indoor plants", 300.0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "PlantStores",
                keyColumn: "StoreId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "PlantStores",
                keyColumn: "StoreId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 10);
        }
    }
}
