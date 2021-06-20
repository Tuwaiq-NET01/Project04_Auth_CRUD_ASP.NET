using Microsoft.EntityFrameworkCore.Migrations;

namespace mininet.Migrations
{
    public partial class AlterColumnText2Desc_RssFeedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "rssFeeds",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "rssFeeds",
                newName: "Text");
        }
    }
}
