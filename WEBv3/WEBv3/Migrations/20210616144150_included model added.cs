using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBv3.Migrations
{
    public partial class includedmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Included",
                columns: table => new
                {
                    IncludedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourGuide = table.Column<bool>(type: "bit", nullable: false),
                    Transport = table.Column<bool>(type: "bit", nullable: false),
                    EntiranceFees = table.Column<bool>(type: "bit", nullable: false),
                    PickUpAndDrop = table.Column<bool>(type: "bit", nullable: false),
                    Food = table.Column<bool>(type: "bit", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Included", x => x.IncludedId);
                    table.ForeignKey(
                        name: "FK_Included_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Included_TourId",
                table: "Included",
                column: "TourId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Included");
        }
    }
}
