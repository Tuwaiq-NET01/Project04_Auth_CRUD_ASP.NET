using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectMVC.Data.Migrations
{
    public partial class AddTablesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Massage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "PlantCares",
                columns: table => new
                {
                    PlantCareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    light = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    irrigation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantCares", x => x.PlantCareId);
                });

            migrationBuilder.CreateTable(
                name: "PlantStores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorePhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantStores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PlantHeight = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantStoreStoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_PlantStores_PlantStoreStoreId",
                        column: x => x.PlantStoreStoreId,
                        principalTable: "PlantStores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantStoreStoreId",
                table: "Plants",
                column: "PlantStoreStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PlantCares");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantStores");
        }
    }
}
