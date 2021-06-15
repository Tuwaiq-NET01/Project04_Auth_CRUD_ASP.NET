using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project04_Auth_CRUD_ASP.NET.Data.Migrations
{
    public partial class v33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("102f54ee-893d-4b81-afb8-5889a83efcab"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("606a470b-e8f7-4e4c-afb4-2a6ff646148a"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("69a9995c-1ff5-4e22-8aad-ff684c14ba07"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("8108f512-1a1f-4493-bc6d-5e6ca3053eba"));

            migrationBuilder.CreateTable(
                name: "ReservationModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationModel_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationModel_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("d54ee885-7e7d-4241-996d-b46ca2c86e17"), "Morning" },
                    { new Guid("3b7036c4-6996-4a26-b3e8-730b64913b4d"), "Afternoon" },
                    { new Guid("826c7869-e68a-41f7-a6b5-c1b86fc00ea4"), "Evening" },
                    { new Guid("90c93261-d00d-4404-988b-b19475f6caae"), "Midnight" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationModel_PriceId",
                table: "ReservationModel",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationModel_UserId1",
                table: "ReservationModel",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationModel");

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("3b7036c4-6996-4a26-b3e8-730b64913b4d"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("826c7869-e68a-41f7-a6b5-c1b86fc00ea4"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("90c93261-d00d-4404-988b-b19475f6caae"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("d54ee885-7e7d-4241-996d-b46ca2c86e17"));

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("606a470b-e8f7-4e4c-afb4-2a6ff646148a"), "Morning" },
                    { new Guid("102f54ee-893d-4b81-afb8-5889a83efcab"), "Afternoon" },
                    { new Guid("8108f512-1a1f-4493-bc6d-5e6ca3053eba"), "Evening" },
                    { new Guid("69a9995c-1ff5-4e22-8aad-ff684c14ba07"), "Midnight" }
                });
        }
    }
}
