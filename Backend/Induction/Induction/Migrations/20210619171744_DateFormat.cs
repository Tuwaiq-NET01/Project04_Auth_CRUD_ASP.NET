using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Induction.Migrations
{
    public partial class DateFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChapterChunks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 193, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "ChapterChunks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 193, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 193, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 193, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Motivations",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 192, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Motivations",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 20, 17, 44, 193, DateTimeKind.Local).AddTicks(509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChapterChunks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 680, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "ChapterChunks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 680, DateTimeKind.Utc).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "Facts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Motivations",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 678, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Motivations",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 19, 16, 40, 16, 679, DateTimeKind.Utc).AddTicks(74));
        }
    }
}
