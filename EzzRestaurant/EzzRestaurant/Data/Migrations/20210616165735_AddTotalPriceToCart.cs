using Microsoft.EntityFrameworkCore.Migrations;

namespace EzzRestaurant.Data.Migrations
{
    public partial class AddTotalPriceToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Cart",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Cart");
        }
    }
}
