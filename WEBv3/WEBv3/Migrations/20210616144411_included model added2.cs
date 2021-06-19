using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBv3.Migrations
{
    public partial class includedmodeladded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Included_Tours_TourId",
                table: "Included");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Included",
                table: "Included");

            migrationBuilder.RenameTable(
                name: "Included",
                newName: "Includeds");

            migrationBuilder.RenameIndex(
                name: "IX_Included_TourId",
                table: "Includeds",
                newName: "IX_Includeds_TourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Includeds",
                table: "Includeds",
                column: "IncludedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Includeds_Tours_TourId",
                table: "Includeds",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Includeds_Tours_TourId",
                table: "Includeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Includeds",
                table: "Includeds");

            migrationBuilder.RenameTable(
                name: "Includeds",
                newName: "Included");

            migrationBuilder.RenameIndex(
                name: "IX_Includeds_TourId",
                table: "Included",
                newName: "IX_Included_TourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Included",
                table: "Included",
                column: "IncludedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Included_Tours_TourId",
                table: "Included",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
