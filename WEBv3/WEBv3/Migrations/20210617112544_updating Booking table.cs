using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBv3.Migrations
{
    public partial class updatingBookingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Bookings");
        }
    }
}
