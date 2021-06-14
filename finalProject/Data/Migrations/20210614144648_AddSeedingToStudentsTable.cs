using Microsoft.EntityFrameworkCore.Migrations;

namespace finalProject.Data.Migrations
{
    public partial class AddSeedingToStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "email", "name" },
                values: new object[,]
                {
                    { 1, "Afra@gmail.com", "Afra" },
                    { 2, "Norah@mail.com", "Norah" },
                    { 3, "taif@mail.com", "taif" },
                    { 4, "sara@mail.com", "sara" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
