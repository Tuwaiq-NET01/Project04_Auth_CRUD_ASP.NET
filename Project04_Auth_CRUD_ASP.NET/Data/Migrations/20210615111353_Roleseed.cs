using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project04_Auth_CRUD_ASP.NET.Data.Migrations
{
    public partial class Roleseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("b93ed6f1-b6e6-4725-b36c-67bc95193cc4"), "Morning" },
                    { new Guid("f44ffdf1-9dd3-4c56-9953-835b1b4c5e52"), "Afternoon" },
                    { new Guid("d6e2f604-a087-4efd-8387-c7c57228ecac"), "Evening" },
                    { new Guid("ae7003a8-1c36-4276-a68c-a1bddbc71590"), "Midnight" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("ae7003a8-1c36-4276-a68c-a1bddbc71590"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("b93ed6f1-b6e6-4725-b36c-67bc95193cc4"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("d6e2f604-a087-4efd-8387-c7c57228ecac"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("f44ffdf1-9dd3-4c56-9953-835b1b4c5e52"));

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
        }
    }
}
