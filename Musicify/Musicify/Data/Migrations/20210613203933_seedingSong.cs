using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class seedingSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Type", "URL" },
                values: new object[] { 1, "Sw3at alaseel", "Classic", "https://soundcloud.com/talal_maddah/w2bhodwmmfxr" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Type", "URL" },
                values: new object[] { 2, "shift abha", "Classic", "https://soundcloud.com/talal_maddah/zfpybtqymc2d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
