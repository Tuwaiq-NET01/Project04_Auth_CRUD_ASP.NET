using Microsoft.EntityFrameworkCore.Migrations;

namespace Podcast_Website.Data.Migrations
{
    public partial class TagPodcastRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Podcast__Id",
                table: "Prodcast_Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Prodcast_Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prodcast_Tag_Podcast__Id",
                table: "Prodcast_Tag",
                column: "Podcast__Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prodcast_Tag_TagId",
                table: "Prodcast_Tag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcast_Tag_Podcasts_Podcast__Id",
                table: "Prodcast_Tag",
                column: "Podcast__Id",
                principalTable: "Podcasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcast_Tag_Tags_TagId",
                table: "Prodcast_Tag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodcast_Tag_Podcasts_Podcast__Id",
                table: "Prodcast_Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodcast_Tag_Tags_TagId",
                table: "Prodcast_Tag");

            migrationBuilder.DropIndex(
                name: "IX_Prodcast_Tag_Podcast__Id",
                table: "Prodcast_Tag");

            migrationBuilder.DropIndex(
                name: "IX_Prodcast_Tag_TagId",
                table: "Prodcast_Tag");

            migrationBuilder.DropColumn(
                name: "Podcast__Id",
                table: "Prodcast_Tag");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Prodcast_Tag");
        }
    }
}
