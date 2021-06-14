using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project04_Auth_CRUD_ASP.NET.Data.Migrations
{
    public partial class v2migrationsbarberpricerelaations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BarberId",
                table: "Prices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prices_BarberId",
                table: "Prices",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Barbers_BarberId",
                table: "Prices",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Barbers_BarberId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_BarberId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "BarberId",
                table: "Prices");
        }
    }
}
