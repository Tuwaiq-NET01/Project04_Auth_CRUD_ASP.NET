using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejar.Migrations
{
    public partial class ChangedDateOnTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedFrom",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "ReservedUntil",
                table: "Trip");

            migrationBuilder.AddColumn<string>(
                name: "DateReservedFrom",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateReservedUntil",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeReservedFrom",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeReservedUntil",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReservedFrom",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DateReservedUntil",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "TimeReservedFrom",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "TimeReservedUntil",
                table: "Trip");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedFrom",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedUntil",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
