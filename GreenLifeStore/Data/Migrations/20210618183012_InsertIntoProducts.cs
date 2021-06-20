using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class InsertIntoProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Image", "Name", "Price", "ProductDetails" },
                values: new object[,]
                {
                    { 1, "https://www.l-organic.com/wp-content/uploads/2018/05/naturya-wheatgrass-1-600x600.jpg", "Naturya Organic Wheatgrass Powder", 97f, "High in protein which contributes to the growth and maintenance of muscle mass Rich in iron which contributes to the normal transport of oxygen around the body and the reduction of tiredness and fatigue Natural source of vitamin A which contributes to the maintenance of normal skin and vision" },
                    { 2, "https://www.l-organic.com/wp-content/uploads/2021/03/51BStX6N-L._AC_SS450_.jpg", "Clearspring Matcha Pouch", 90.5f, "Matcha is a finely milled vibrant green tea powder made from the highest quality Japanese tea leaves. Clearspring Organic Premium Matcha comes from Uji, a region high in the hills around Kyoto, renowned for producing the best Japanese teas. Only accessibly by foot, this remote area is unpolluted and rich in friendly bugs such as spiders, ladybirds, praying mantis and dragonflies to keep the pests under control (best to use organic matcha as non-organic matcha is grown using excessive amounts of agricultural fertilisers and pesticides)." },
                    { 3, "https://www.l-organic.com/wp-content/uploads/2018/09/hampstead-peppermint.jpg", "Hampstead Organic Peppermint Tea", 17f, "Hampsteads organic peppermint infusion is a full flavoured, and heady. It is a unique blend of the two best loved mints, peppermint and spearmint. This gives added depth, and a fresh, tangy finish with a lingering sweet after taste. Deliciously refreshing hot or iced as a cooling summer cocktail, it is the perfect pick-me-up during the day or after a meal to cleanse the palate and aid digestion." },
                    { 4, "https://www.l-organic.com/wp-content/uploads/2018/04/alphabites-600x600.jpg", "Bear Alphabites Cocoa Cereal", 32f, "Alphabites are a delicious healthy breakfast with no refined sugar or salt. Grrr. We use coconut blossom nectar, which low GI** and naturally high in calcium." },
                    { 5, "https://www.l-organic.com/wp-content/uploads/2018/10/natures-path-crispy-rice.jpg", "Nature’s Path Crispy Rice Cereal", 30f, "Nature’s Path Organic Gluten Free Crispy Rice Cereal is a delicious, crunchy cereal that has been wonderfully made with organic brown rice." },
                    { 6, "https://www.l-organic.com/wp-content/uploads/2018/03/Doves-Farm-Organic-Corn-Flakes-325g-1-600x600.jpg", "Doves Farm Organic Corn Flakes", 29f, "Doves Farm Organic Corn Flakes are gluten free and low in fat. Start your day with a bowl of our delicious golden flakes which are grown under the Italian sun. We’ve added malted rice syrup to create our delicious breakfast suitable for all the family." },
                    { 7, "https://www.l-organic.com/wp-content/uploads/2019/01/amisa-fruity-oat-600x600.png", "Amisa Fruity Oat Muesli Cranberry & Strawberry", 29f, "Amisa Organic Gluten Free Fruity Oat Muesli is a delicious gluten free muesli, with tangy cranberries, juicy strawberries, and sunflower seeds." },
                    { 8, "https://www.l-organic.com/wp-content/uploads/2018/02/88.jpg", "Biona Maple Syrup Waffles", 21f, "Organic wholegrain waffles with rich maple syrup filling. Perfect for dunking, crunching or munching on the go!" },
                    { 9, "https://www.l-organic.com/wp-content/uploads/2019/01/biona-apple-juice-1l.jpg", "Biona Organic Pressed Apple Juice", 27f, "Unfiltered pure organic apple juice, with the bits. Biona organic cloudy Apple Juice is simply pressed, so more of its goodness reaches your glass." },
                    { 10, "https://www.l-organic.com/wp-content/uploads/2020/05/Biona-Organic-Peach-Halves-in-Rice-Syrup-550g--600x600.jpg", "Biona Organic Peach Halves", 40f, "Naturally sweet and delicious, Peach Halves in Rice Syrup contains no added beet or cane sugar. Picked at the peak of ripeness and minimally processed," }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }
    }
}
