using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class restOfTablesWithManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fanReqeustCelebrities",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    From = table.Column<string>(type: "TEXT", nullable: true),
                    To = table.Column<string>(type: "TEXT", nullable: true),
                    RequstDec = table.Column<string>(type: "TEXT", nullable: true),
                    AllowPubiling = table.Column<bool>(type: "INTEGER", nullable: false),
                    CelebrityId = table.Column<int>(type: "INTEGER", nullable: false),
                    FanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fanReqeustCelebrities", x => x.id);
                    table.ForeignKey(
                        name: "FK_fanReqeustCelebrities_celebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "celebrities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fanReqeustCelebrities_fans_FanId",
                        column: x => x.FanId,
                        principalTable: "fans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fanReqeustCelebrities_CelebrityId",
                table: "fanReqeustCelebrities",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_fanReqeustCelebrities_FanId",
                table: "fanReqeustCelebrities",
                column: "FanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fanReqeustCelebrities");
        }
    }
}
