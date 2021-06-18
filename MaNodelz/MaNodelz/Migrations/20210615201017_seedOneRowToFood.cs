using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaNodelz.Migrations
{
    public partial class seedOneRowToFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "FoodDescription", "FoodImage", "FoodName", "FoodTobePrepared", "FoodType" },
                values: new object[] { 1, "Hokagy's way of making nodelz", "https://favy-inbound-singapore.s3.amazonaws.com/uploads/topic_item/image/76335/retina_tokyo_style_ramen_with_Naruto.jpg", "Naruto's Nodelz", new TimeSpan(0, 0, 20, 10, 0), "Nodelz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
