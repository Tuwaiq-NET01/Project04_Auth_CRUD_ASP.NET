using Microsoft.EntityFrameworkCore.Migrations;

namespace circus.Data.Migrations
{
    public partial class InsertPerformers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Image", "Name", "Profession" },
                values: new object[] { 1, "https://www.cirquedusoleil.com/-/media/cds/images/shows/o/new/highlights/o_highlights_04_fire_942x570.jpg?h=570&w=942&hash=BE7D8FBFCAF7B9BAD5012DEACED51973D0617C26", "O", "Divers" });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Image", "Name", "Profession" },
                values: new object[] { 2, "https://www.cirquedusoleil.com/-/media/cds/images/shows/mystere/new/highlights/mystere_highlights_06_powertrack_942x570.jpg?h=570&w=942&hash=D3183E25FD15F5DD8B95BBBB6A7C3EB93E131D33", "Mystère", "Acrobatics and dancers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
