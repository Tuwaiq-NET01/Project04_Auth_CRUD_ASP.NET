using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class InsertIntoBranches2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "Name" },
                values: new object[] { 1, "Riyadh", "Green Life Store" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "Name" },
                values: new object[] { 2, "Dammam", "Green Life Store" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "Name" },
                values: new object[] { 3, "Jeddah", "Green Life Store" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3);
        }
    }
}
