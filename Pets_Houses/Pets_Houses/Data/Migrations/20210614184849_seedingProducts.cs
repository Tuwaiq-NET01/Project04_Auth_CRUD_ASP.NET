using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets_Houses.Data.Migrations
{
    public partial class seedingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "ProductName", "Type" },
                values: new object[,]
                {
                    { 1, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/1a0a7e95-de58-40c8-bb0e-811668f82b92.jpg", 10f, "Vitakraft Cat Stick Mini Duck and Rabbit", "Food" },
                    { 19, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/fcb3def2-b06e-458d-8a44-f31b2ed5a2d4.png", 17f, "Playing rope with woven in ball", "Toy" },
                    { 18, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/f576c5a4-01c6-4ad9-92fd-33d7bdf39739.jpg", 7f, "Playing Rope 20 cm", "Toy" },
                    { 17, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/bdfeabe4-89ff-4870-8d5e-f1f4c437b7c4.png", 29f, "Playing Rod For Cats", "Toy" },
                    { 16, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/b2dfb935-a807-4437-9b80-87c5c66d7b5d.png", 17f, "Owl Toy With Catnip", "Toy" },
                    { 15, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/b1108e16-7231-4f54-9a56-bf38d03ead8e.png", 88f, "Playing tunnel fleece colourful 25×50 cm", "Toy" },
                    { 14, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/553f21d9-01de-4160-9359-c3fd18a4a20f.png", 17f, "Playing rod with bird With catnip", "Toy" },
                    { 13, "Weight : 1Kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/d70fc4c6-6a26-403f-8e46-f1f207e5c742.jpg", 30f, "Brit Dog Dry Food Champion Salmon", "Food" },
                    { 12, "Weight : 3Kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/ef59e7b5-0d71-4f00-8a63-50e3d05ece52.jpg", 54f, "Brit Puppy Dry Food Lamb&Rice ", "Food" },
                    { 20, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/12bac90a-0e58-4b89-b33a-ae15a564e81f.png", 19f, "Dumbbell For Play 19 cm", "Toy" },
                    { 11, "Weight : 3Kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/962bf854-0225-4cf4-aca1-63acdb61193e.jpg", 50f, "Brit Dog Dry Food Adult M Chicken", "Food" },
                    { 9, "Weight : 3Kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/c7949b39-af12-4ab4-a877-8872339f4443.jpg", 48f, "Brit Dog Dry Food Sensitive Lamb", "Food" },
                    { 8, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/84651856-a067-475c-aa0b-9365840f9877.jpg", 14f, "GimCat Latte Milk Low in Lactose, 200ml", "Food" },
                    { 7, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/39470729-761d-4efe-8eb0-9748d409cec3.png", 8f, "Vitakraft Cat Yums Chicken and Cat Grass", "Food" },
                    { 6, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/3efd1f79-358e-431f-9700-9cd20dec2af2.jpg", 20f, "GimCat Skin & Coat Tabs Beauty Complex", "Food" },
                    { 5, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/c3c88b68-374a-4324-9902-4b4d079d8c60.jpg", 8f, "Vitakraft Cat Yums Liver Sausage", "Food" },
                    { 4, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/000b5181-c161-4ccb-aa39-b1f8fce5c4d3.png", 7f, "S1 Nutram Sound Blaanced Wellness Kitten Canned Food", "Food" },
                    { 3, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/881b50e2-5d84-46aa-b747-e0a12cb75bd0.png", 10f, "I17 Nutram Ideal Solution Support Indoor Cat Canned Food", "Food" },
                    { 2, "Weight: 1.4kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/30f89668-6e1e-4691-bf5f-65c51a88fc53.jpg", 40f, "Burgess Old Cat Food with Turkey & Berries", "Food" },
                    { 10, "Weight : 8Kg", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/ad295124-4190-472c-99d2-b3d4b4a5a7f6.jpg", 120f, "Brit Dog Dry Food Junior S Chicken", "Food" },
                    { 21, "", "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/994397bc-6668-4823-adee-ae6ec1f3d43f.jpeg", 30f, "BE NORDIC whale Brunold, plush, 25 cm", "Toy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
