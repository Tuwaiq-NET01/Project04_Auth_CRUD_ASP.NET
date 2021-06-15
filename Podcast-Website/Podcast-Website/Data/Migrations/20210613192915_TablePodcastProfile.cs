using Microsoft.EntityFrameworkCore.Migrations;

namespace Podcast_Website.Data.Migrations
{
    public partial class TablePodcastProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.CreateTable(
                name: "PodcastProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastProfile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PodcastProfile");

        }
    }
}
