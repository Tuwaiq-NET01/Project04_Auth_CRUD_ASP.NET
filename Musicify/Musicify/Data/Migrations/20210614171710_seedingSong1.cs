using Microsoft.EntityFrameworkCore.Migrations;

namespace Musicify.Data.Migrations
{
    public partial class seedingSong1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "SingerId", "Type", "URL" },
                values: new object[] { 1, "Sw3at alaseel", 2, "Classic", "https://soundcloud.com/talal_maddah/w2bhodwmmfxr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
