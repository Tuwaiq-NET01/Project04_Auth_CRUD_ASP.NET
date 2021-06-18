using Microsoft.EntityFrameworkCore.Migrations;

namespace _Platform_.Data.Migrations
{
    public partial class InsertNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CharityId", "Description", "Image", "Subject" },
                values: new object[] { 1, 1, "وقعت شركة «لجام للرياضة» المالك والمشغل لأندية «وقت اللياقة»، والمؤسسة الخيرية لرعاية الأيتام «إخاء» اتفاقية تمديد الشراكة", "https://donatesstorage.blob.core.windows.net/all/3781.png", "إخاء” و”وقت اللياقة” توقعان اتفاقية تمديد الشراكة لرعاية الأيتام" });

            migrationBuilder.InsertData(
                table: "ambassador",
                columns: new[] { "Id", "CharityId", "Description", "Email", "FirstName", "Image", "LastName" },
                values: new object[] { 1, 1, "المؤسسة الخيرية لرعاية الأيتام", "amalFreeh1@gmail.com", "أمل", "https://donatesstorage.blob.core.windows.net/all/3781.png", "المطيري" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ambassador",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
