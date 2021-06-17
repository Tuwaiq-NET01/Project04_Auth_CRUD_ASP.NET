using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class insertTools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ID", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 4, "70 Tache Espresso Glass Standard with a capacity of 70ml\r\n             Double flow, smooth design and convenient pour handle\r\n              Marks listed in milliliters and ounces", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/Artboard_6_1df5b44a-0936-4182-9f24-cf9f355ebb65_700x.jpg?v=1599732510", "Tach standard espresso glass" },
                    { 5, "Made of stainless steel, resistant to high temperatures, silver color\r\n            The temperature is measured in Fahrenheit.\r\n            Compatible with all types of steaming jugs", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/0007__DSC0882_1000x.jpg?v=1611678428", "Tach thermometer for steaming milk" },
                    { 6, "Cloth towel made of cloth and silicone,Suitable for cleaning steam wand Made of three layers to protect against high heat", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/DSC3126_1000x.jpg?v=1611737108", "TASH Cloth Steamer Wand Cleaning Towel" },
                    { 7, "Suitable for home and professional barista use, you can monitor and control the time and weight via a built-in smart screen.", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/51b7HH9VVfL._AC_SL1100_1000x.jpg?v=1603869810", "Taymore white digital scale" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
