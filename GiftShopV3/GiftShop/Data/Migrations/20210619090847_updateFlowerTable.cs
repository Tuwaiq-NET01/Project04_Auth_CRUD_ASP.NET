using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class updateFlowerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flowers",
                newName: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlowerId",
                table: "Flowers",
                newName: "Id");
        }
    }
}
