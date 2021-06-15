using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class insertBeans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Beans",
                columns: new[] { "ID", "Country", "Image", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Colombia", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/37_600x.png?v=1621461202", "Tuwaiq", "Washed" },
                    { 2, "Guatemala", "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/36_b624fe7b-9f13-4c19-bf4b-3f8de041b668_1200x.png?v=1621461554", "Qiddiya", "Washed" },
                    { 3, "El Salvador", "https://camelstep.com/media/catalog/product/cache/cb1cf9ef08bd8ac078031d7ecd205277/_/-/_-__1_8.jpg", "El Salvador Baraona", "Natural" },
                    { 4, "Ethiopia", "https://camelstep.com/media/catalog/product/cache/cb1cf9ef08bd8ac078031d7ecd205277/_/-/_-__1_5.jpg", "Ethiopia Ariti", "Natural" },
                    { 5, "Uganda", "https://cdn.salla.sa/WyvX/PJUADylqF3BnEfwx7oqnmt8WwNV721uy1aaNc829.jpg", "Mananasi Espresso", "Natural" },
                    { 6, "Ethiopia", "https://media.zid.store/52ed14bd-6baf-41c5-b177-f31d72230645/416c2414-507d-4225-89a2-80f5d789861b.png", "Chelbesa", "Natural" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
