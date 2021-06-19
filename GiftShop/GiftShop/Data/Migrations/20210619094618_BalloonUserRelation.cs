using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class BalloonUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balloon_User_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalloonId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balloon_User_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balloon_User_Model_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Balloon_User_Model_Balloons_BalloonId",
                        column: x => x.BalloonId,
                        principalTable: "Balloons",
                        principalColumn: "BalloonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balloon_User_Model_BalloonId",
                table: "Balloon_User_Model",
                column: "BalloonId");

            migrationBuilder.CreateIndex(
                name: "IX_Balloon_User_Model_UserId1",
                table: "Balloon_User_Model",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balloon_User_Model");
        }
    }
}
