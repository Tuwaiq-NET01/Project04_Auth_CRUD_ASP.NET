using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class addedFlowersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    FlowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.FlowerId);
                });

            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "FlowerId", "FlowerImage", "FlowerName", "FlowerPrice" },
                values: new object[,]
                {
                    { 101, "https://floward.imgix.net/web/Files/thumPro/637447438702232017.jpg?w=500", "Pink Dust", 310.50m },
                    { 102, "https://floward.imgix.net/web/Files/thumPro/637375823162633954.jpg?w=500", "Breeze", 322.00m },
                    { 103, "https://floward.imgix.net/web/Files/thumPro/637467433600235841.jpg?w=500", "Love Mix", 360.00m },
                    { 104, "https://floward.imgix.net/web/Files/thumPro/637368837979802520.jpg?width=600", "Sleek Bouquet", 200.00m },
                    { 105, "https://floward.imgix.net/web/Files/thumPro/637363759603959215.jpg?width=600", "35 Roses hand bouquet III", 280.00m },
                    { 106, "https://floward.imgix.net/web/Files/thumPro/637363761825283068.jpg?width=600", "50 Roses hand bouquet II", 414.00m },
                    { 107, "https://floward.imgix.net/web/Files/thumPro/637448274952847223.jpg?width=600", "White and Yellow Roses", 230.50m },
                    { 108, "https://floward.imgix.net/web/Files/thumPro/637503588358822359.jpg?width=600", "Pink Roses", 312.00m },
                    { 109, "https://floward.imgix.net/web/Files/thumPro/637502715042825399.jpg?width=600", "Purple Tulips", 430.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flowers");
        }
    }
}
