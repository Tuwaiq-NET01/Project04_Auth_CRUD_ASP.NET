using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class removeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Singers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Singers",
                columns: new[] { "Id", "Info", "Name", "Photo" },
                values: new object[] { 1, "Talal Maddah, Saudi singer and composer. He has a tremendous impact on Arab culture in the 20th century, and he is the pioneer of modernity in Saudi song, and he is considered the most prominent Saudi artist. He was one of the first who contributed to the spread of the Saudi song outside the Kingdom, as he sang in many cities around the world such as Paris and London.", "Talal", "https://pbs.twimg.com/profile_images/1366678263997865987/Hc9pCnMa.jpg" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Type", "URL" },
                values: new object[] { 1, "Sw3at alaseel", "Classic", "https://soundcloud.com/talal_maddah/w2bhodwmmfxr" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Type", "URL" },
                values: new object[] { 2, "shift abha", "Classic", "https://soundcloud.com/talal_maddah/zfpybtqymc2d" });
        }
    }
}
