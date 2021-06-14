using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShopV1.Data.Migrations
{
    public partial class AddedDataFlowersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "FlowerId", "FlowerImage", "FlowerName", "FlowerPrice" },
                values: new object[] { 10, "https://floward.imgix.net/web/Files/thumPro/637447438702232017.jpg?w=500", "Pink Dust", 310.50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "FlowerId",
                keyValue: 10);
        }
    }
}
