using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class CreateTableVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelebrityVideo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    video = table.Column<string>(type: "TEXT", nullable: true),
                    CelebrityId = table.Column<int>(type: "INTEGER", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelebrityVideo_CelebrityId",
                table: "CelebrityVideo",
                column: "CelebrityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelebrityVideo");
        }
    }
}
