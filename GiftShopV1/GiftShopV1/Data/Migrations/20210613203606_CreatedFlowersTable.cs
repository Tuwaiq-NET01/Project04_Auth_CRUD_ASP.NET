using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShopV1.Data.Migrations
{
    public partial class CreatedFlowersTable : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flowers");
        }
    }
}
