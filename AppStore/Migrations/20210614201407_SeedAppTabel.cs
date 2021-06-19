using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStore.Migrations
{
    public partial class SeedAppTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apps",
                columns: new[] { "Id", "AverageRating", "Description", "DownloadsCount", "GeneralCategory", "Icon", "Name", "Size" },
                values: new object[,]
                {
                    { 1, 0f, "Massenger App", 0, "Social Media", "https://upload.wikimedia.org/wikipedia/commons/6/6b/WhatsApp.svg", "Whatsapp", "100MB" },
                    { 2, 0f, "Tweets App", 0, "Social Media", "https://png.pngtree.com/png-clipart/20190613/original/pngtree-twitter-icon-png-image_3584901.jpg", "Twitter", "40MB" },
                    { 3, 0f, "Social Media App", 0, "Social Media", "https://facebookbrand.com/wp-content/uploads/2019/04/f_logo_RGB-Hex-Blue_512.png?w=512&h=512", "FaceBook", "150MB" },
                    { 4, 0f, "League Of Legends On Mobile", 0, "Games", "https://static.wikia.nocookie.net/leagueoflegends/images/b/be/Wild_Rift_icon.png/revision/latest?cb=20191018194406", "Wild Rift", "3GB" },
                    { 5, 0f, "Chess Game", 0, "Games", "https://media.istockphoto.com/vectors/chess-icon-on-white-background-vector-id931757036", "Chess", "20MB" },
                    { 6, 0f, "Building, Survival Game", 0, "Games", "https://external-preview.redd.it/INBHMCNdcPNCBvgGn3yQ-RH4jiAhFP4bde7-wCC2xiw.png?auto=webp&s=7fbcf884991ea6c916da84752af364fbf962687b", "Minecraft", "250MB" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Apps",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
