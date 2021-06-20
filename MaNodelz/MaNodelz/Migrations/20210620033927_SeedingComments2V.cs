using Microsoft.EntityFrameworkCore.Migrations;

namespace MaNodelz.Migrations
{
    public partial class SeedingComments2V : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FoodId" },
                values: new object[,]
                {
                    { 8, "The dish was amazing", 9 },
                    { 9, "The dish was amazing", 10 },
                    { 10, "The dish was amazing", 10 },
                    { 11, "The dish was amazing", 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
