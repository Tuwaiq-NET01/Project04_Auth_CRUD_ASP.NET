using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class addedPresentorSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Presentors",
                columns: new[] { "Id", "Email", "Field", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "spurofthemoment@gmail.com", "IT", "Sameera Alhussainy", 556110112 },
                    { 2, "ceo@tesla.com", "Business", "Elon Musk", 556123123 },
                    { 3, "mj@gmail.com", "Health", "Michael Jackson", 522666987 },
                    { 4, "steven@galaxybrain.com", "Science", "Steven Hawking", 598644222 },
                    { 5, "hala@galaxybrain.com", "Bullshit", "Hala Alyousef", 522441234 },
                    { 6, "reema@galaxybrain.com", "Divine Philosophy", "Reema Alyousef", 547722199 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Presentors",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
