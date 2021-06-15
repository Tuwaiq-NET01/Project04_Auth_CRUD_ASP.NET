using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class insertRoaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Roasteries",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://octave.coffee/wp-content/uploads/2021/04/chilbisa.jpg");

            migrationBuilder.InsertData(
                table: "Roasteries",
                columns: new[] { "ID", "Image", "Location", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "https://media.zid.store/cdbbc706-61b2-4d93-9791-9f65743fe34b/ac8422ff-c987-4f26-8185-8c5cfe0464b9.jpeg", "Maddinah", "Kiffa Roaster", 4.4 },
                    { 2, "https://pbs.twimg.com/profile_images/1313161853045035008/womhVuch_400x400.jpg", "Riyadh", "Arriyadh Roaster", 4.6 },
                    { 3, "https://modernsupply.com.sa/wp-content/uploads/2021/03/31.jpg", "Jeddah", "Suwaa Roaster", 4.5 },
                    { 4, "http://cdn.shopify.com/s/files/1/0257/0046/6776/collections/image_2d2722a5-3abe-4199-b964-5859ca7b790c_1200x1200.png?v=1584446917", "Khobar", "Camel Step Roaster", 4.3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roasteries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roasteries",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roasteries",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roasteries",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Roasteries",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "https://media.zid.store/52ed14bd-6baf-41c5-b177-f31d72230645/416c2414-507d-4225-89a2-80f5d789861b.png");
        }
    }
}
