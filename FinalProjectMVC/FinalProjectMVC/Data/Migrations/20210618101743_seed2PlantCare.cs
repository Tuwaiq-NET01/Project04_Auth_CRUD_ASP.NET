using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectMVC.Data.Migrations
{
    public partial class seed2PlantCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 110,
                column: "plantId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 210,
                column: "plantId",
                value: 2);

            migrationBuilder.InsertData(
                table: "PlantCares",
                columns: new[] { "PlantCareId", "irrigation", "light", "plantId", "temperature" },
                values: new object[,]
                {
                    { 310, "Twice", "No", 3, 28.0 },
                    { 410, "Once", "No", 4, 25.0 },
                    { 510, "Twice", "Yes", 5, 20.0 },
                    { 610, "Once", "Yes", 6, 25.0 },
                    { 710, "Twice", "No", 7, 29.0 },
                    { 810, "Once", "No", 8, 25.0 },
                    { 910, "Twice", "Yes", 9, 30.0 },
                    { 1110, "Once", "No", 10, 25.0 },
                    { 2110, "Twice", "Yes", 11, 20.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 2110);

            migrationBuilder.UpdateData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 110,
                column: "plantId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PlantCares",
                keyColumn: "PlantCareId",
                keyValue: 210,
                column: "plantId",
                value: 0);
        }
    }
}
