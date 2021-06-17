using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class addedAttendeeSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "Field", "Name", "Phone" },
                values: new object[] { 1, "reema@gmail.com", "IT", "Reema Alyousef", 547722199 });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "Field", "Name", "Phone" },
                values: new object[] { 2, "hala@gmail.com", "Business", "Hala Alyousef", 554124771 });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "Field", "Name", "Phone" },
                values: new object[] { 3, "durrdurr@gmail.com", "Marketing", "Dorrah Alsaad", 532121731 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
