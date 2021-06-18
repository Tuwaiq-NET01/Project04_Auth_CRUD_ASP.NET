using Microsoft.EntityFrameworkCore.Migrations;

namespace _Platform_.Data.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Charity",
                columns: new[] { "Id", "CharityName", "Description", "Image", "Url", "UserId" },
                values: new object[] { 1, "إخاء", "المؤسسة الخيرية لرعاية الأيتام", "https://donatesstorage.blob.core.windows.net/all/3781.png", "https://store.ekhaa.org.sa/", "3396a74c-3bf8-4e01-b8fe-9a417777907d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charity",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
