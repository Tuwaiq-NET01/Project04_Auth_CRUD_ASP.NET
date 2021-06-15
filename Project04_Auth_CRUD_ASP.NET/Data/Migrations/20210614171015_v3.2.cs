using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project04_Auth_CRUD_ASP.NET.Data.Migrations
{
    public partial class v32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("8d6eaf99-36da-4d8e-a704-4b53df6d593c"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("91bb1042-9213-400a-bb1e-a33533e5a0ec"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("962d855b-13b9-4d00-a8d5-b9721e23cf0b"));

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: new Guid("adce4ad9-d746-4ca8-986c-eb8f13196513"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("adce4ad9-d746-4ca8-986c-eb8f13196513"), "Morning" },
                    { new Guid("8d6eaf99-36da-4d8e-a704-4b53df6d593c"), "Afternoon" },
                    { new Guid("91bb1042-9213-400a-bb1e-a33533e5a0ec"), "Evening" },
                    { new Guid("962d855b-13b9-4d00-a8d5-b9721e23cf0b"), "Midnight" }
                });
        }
    }
}
