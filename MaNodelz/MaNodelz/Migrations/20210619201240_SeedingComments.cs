using Microsoft.EntityFrameworkCore.Migrations;

namespace MaNodelz.Migrations
{
    public partial class SeedingComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "FoodId" },
                values: new object[,]
                {
                    { 1, "The dish was amazing", 1 },
                    { 2, "Dude it's NARUTO'S NODELZZZ OMGGG", 1 },
                    { 3, "The dish was amazing", 4 },
                    { 4, "The dish was amazing", 5 },
                    { 5, "The dish was amazing", 6 },
                    { 6, "The dish was amazing", 7 },
                    { 7, "The dish was amazing", 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
