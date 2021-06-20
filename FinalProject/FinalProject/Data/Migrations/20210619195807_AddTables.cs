using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "celebrities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BriefDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroductionVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_celebrities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CelebrityVideo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelebrityId = table.Column<int>(type: "int", nullable: false),
                    FanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrityVideo", x => x.id);
                    table.ForeignKey(
                        name: "FK_CelebrityVideo_celebrities_CelebrityId",
                        column: x => x.CelebrityId,
                        principalTable: "celebrities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrityVideo_fans_FanId",
                        column: x => x.FanId,
                        principalTable: "fans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fanReqeustCelebrities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequstDec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowPubiling = table.Column<bool>(type: "bit", nullable: false),
                    ReqeustState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelebrityId = table.Column<int>(type: "int", nullable: false),
                    FanId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_CelebrityVideo_CelebrityId",
                table: "CelebrityVideo",
                column: "CelebrityId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityVideo_FanId",
                table: "CelebrityVideo",
                column: "FanId");

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
                name: "CelebrityVideo");

            migrationBuilder.DropTable(
                name: "fanReqeustCelebrities");

            migrationBuilder.DropTable(
                name: "celebrities");

            migrationBuilder.DropTable(
                name: "fans");
        }
    }
}
