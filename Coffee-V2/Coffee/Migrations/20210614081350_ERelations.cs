using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee.Migrations
{
    public partial class ERelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoasterID",
                table: "Beans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 1,
                column: "RoasterID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 2,
                column: "RoasterID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 3,
                column: "RoasterID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 4,
                column: "RoasterID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 5,
                column: "RoasterID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Beans",
                keyColumn: "ID",
                keyValue: 6,
                column: "RoasterID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Beans_RoasterID",
                table: "Beans",
                column: "RoasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beans_Roasteries_RoasterID",
                table: "Beans",
                column: "RoasterID",
                principalTable: "Roasteries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beans_Roasteries_RoasterID",
                table: "Beans");

            migrationBuilder.DropIndex(
                name: "IX_Beans_RoasterID",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "RoasterID",
                table: "Beans");
        }
    }
}
