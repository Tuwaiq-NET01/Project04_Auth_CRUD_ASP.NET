using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class updatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event_Attendee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 1,
                column: "EventId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 2,
                column: "EventId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 3,
                column: "EventId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Attendees");

            migrationBuilder.InsertData(
                table: "Event_Attendee",
                columns: new[] { "Id", "AttendeeId", "EventId" },
                values: new object[] { 2, 1, 2 });
        }
    }
}
