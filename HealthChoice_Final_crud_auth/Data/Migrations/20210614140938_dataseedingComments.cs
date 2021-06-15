using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class dataseedingComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "comId", "message" },
                values: new object[] { 1, "Nice" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "comId", "message" },
                values: new object[] { 2, "very suitable" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "comId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "comId",
                keyValue: 2);
        }
    }
}
