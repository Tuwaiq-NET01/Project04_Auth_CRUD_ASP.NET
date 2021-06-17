using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class CreatedSweetsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sweets",
                columns: table => new
                {
                    SweetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SweetImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SweetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SweetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sweets", x => x.SweetId);
                });

            migrationBuilder.InsertData(
                table: "Sweets",
                columns: new[] { "SweetId", "SweetImage", "SweetName", "SweetPrice" },
                values: new object[,]
                {
                    { 201, "https://sa-i1.fnp.com//images/pr/l/v20201205120230/delicious-fudge-cake_1.jpg", "Delicious Fudge Cake 4 Portion", 99.00m },
                    { 202, "https://sa-i1.fnp.com//images/pr/l/v20201205120228/red-velvet-berry-cream-cake_1.jpg", "Red Velvet Berry Cream Cake 6 Portion", 129.00m },
                    { 203, "https://sa-i1.fnp.com//images/pr/l/v20210402160935/creamy-red-velvet-cake_1.jpg", "Creamy Red Velvet Cake Half Kg", 109.00m },
                    { 204, "https://sa-i1.fnp.com/images/pr/l/v20201205120229/crunchy-chocolate-hazelnut-cake_1.jpg", "Crunchy Chocolate Hazelnut Cake 4 Portion", 119.00m },
                    { 205, "https://sa-i1.fnp.com/images/pr/l/v20210402160934/tales-of-taste-ice-cream-cone-cake_1.jpg", "Tales of Taste Ice Cream Cone Cake", 278.00m },
                    { 206, "https://sa-i1.fnp.com/images/pr/l/v20210202110031/heavenly-chocolate-cream-cake_1.jpg", "Heavenly Chocolate Cream Cake Half Kg", 119.00m },
                    { 207, "https://sa-i1.fnp.com//images/pr/l/v20201215142751/the-gentleman-theme-cake_1.jpg", "The Gentleman Theme Cake 8 Portions Vanilla", 279.00m },
                    { 208, "https://sa-i1.fnp.com//images/pr/l/v20210526180156/candy-topped-chocolate-cake_1.jpg", "Candy Topped Chocolate Cake Half Kg", 129.00m },
                    { 209, "https://sa-i1.fnp.com/images/pr/l/v20201215142740/princess-theme-cake_1.jpg", "Princess Theme Cake 12 Portions Vanilla", 399.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sweets");
        }
    }
}
