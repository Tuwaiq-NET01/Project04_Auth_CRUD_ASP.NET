using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class InsertToolsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ID", "Description", "Image", "Name" },
                values: new object[] { 1, "380ml black stainless steel steam jug\r\n             Smooth design and tapered tip for easy drawing and pour control\r\n             in blue", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/DSC2671_1000x.jpg?v=1599727765", "TASH Steamer Jug Navy Blue Sharp" });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ID", "Description", "Image", "Name" },
                values: new object[] { 2, "Stainless steel exposed port filter with black rod Size 54 mm\r\n             Compatible with Breville Barista Express - Sage Machines", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/DSC3839_1000x.jpg?v=1599727217", "Tach port filter exposed" });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ID", "Description", "Image", "Name" },
                values: new object[] { 3, "The Tach Coffee Dispenser The espresso surface dispenser allows for the desired depth to be adjusted to ensure perfect dispensing every time.\r\n              53 mm in size", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/Artboard_7_21f579be-9c5b-413e-8612-6b47f6e76df1.jpg?v=1599734667", "Tach coffee dispenser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
