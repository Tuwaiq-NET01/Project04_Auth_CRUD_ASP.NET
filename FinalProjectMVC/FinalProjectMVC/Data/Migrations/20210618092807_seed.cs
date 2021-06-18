using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectMVC.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Id", "Image", "PlantColor", "PlantHeight", "PlantName", "PlantStoreStoreId", "PlantType", "Price", "StoreId" },
                values: new object[] { 11, null, "https://media.zid.store/thumbs/c9146352-5f34-4d3a-8115-22631018afb2/e19a1dca-ecd5-497b-8c1d-7bf6321a1d8a-thumbnail-370x370.png", "green with purple", 30, "Basil", null, "in/out/door plants", 40.0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 11);
        }
    }
}
