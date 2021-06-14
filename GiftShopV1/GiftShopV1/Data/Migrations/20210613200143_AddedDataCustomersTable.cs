using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShopV1.Data.Migrations
{
    public partial class AddedDataCustomersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "Location", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "Alexia@hotmail.com", "Alexia", "Perry", "NY", "055-569-9110", "AlexPer" },
                    { 2, "RitaF@hotmail.com", "Rita", "Farr", "LA", "050-569-9110", "RitaF" },
                    { 3, "TonyR@hotmail.com", "Tony", "Roberts", "FL", "054-932-6548", "TonyRob" },
                    { 4, "AmeliaO@hotmail.com", "Amelia", "Owen", "CA", "051-436-5094", "AmeliaOwen" },
                    { 5, "KyleF@hotmail.com", "Kyle", "Fox", "NY", "059-330-4393", "KyFox" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);
        }
    }
}
