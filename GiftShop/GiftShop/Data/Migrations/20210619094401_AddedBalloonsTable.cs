using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class AddedBalloonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balloons",
                columns: table => new
                {
                    BalloonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalloonImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalloonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalloonPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balloons", x => x.BalloonId);
                });

            migrationBuilder.InsertData(
                table: "Balloons",
                columns: new[] { "BalloonId", "BalloonImage", "BalloonName", "BalloonPrice" },
                values: new object[,]
                {
                    { 301, "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/0/0/0013475_gold-helium-latex-balloons-6_1.jpeg", "Gold Helium Latex Balloons (6)", 44.00m },
                    { 302, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007414_multi-color-helium-latex-balloons-12_2.jpeg", "Multi-Color Helium Latex Balloons (12)", 87.00m },
                    { 303, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013645_balloon-bouquet-lime-green_2.jpeg", "Balloon Bouquet (Lime Green)", 77.00m },
                    { 304, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0002077_rainbow-surprise_1.jpeg", "Rainbow Surprise Balloon Bouquet", 66.00m },
                    { 305, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0019413_whats-your-number_1.jpeg", "Numeric Balloons", 60.00m },
                    { 306, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013665_balloon-bouquet-red-black_2.jpeg", "Balloon Bouquet (Red & Black)", 148.00m },
                    { 307, "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/9/_/9_2_3.jpg", "8 Chrome Latex Balloons", 116.00m },
                    { 308, "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/7/_/7_1_2_3.jpg", "6 Green Chrome Latex Balloons", 87.00m },
                    { 309, "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007416_pink-helium-latex-balloons-6_2.jpeg", "Pink Helium Latex Balloons (6)", 44.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balloons");
        }
    }
}
