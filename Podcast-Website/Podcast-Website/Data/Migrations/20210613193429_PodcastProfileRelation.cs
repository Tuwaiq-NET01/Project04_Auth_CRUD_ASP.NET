using Microsoft.EntityFrameworkCore.Migrations;

namespace Podcast_Website.Data.Migrations
{
    public partial class PodcastProfileRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "PodcastProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Profile_Id",
                table: "PodcastProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PodcastProfile_PodcastId",
                table: "PodcastProfile",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastProfile_Profile_Id",
                table: "PodcastProfile",
                column: "Profile_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastProfile_Podcasts_PodcastId",
                table: "PodcastProfile",
                column: "PodcastId",
                principalTable: "Podcasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastProfile_Profiles_Profile_Id",
                table: "PodcastProfile",
                column: "Profile_Id",
                principalTable: "Profiles",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PodcastProfile_Podcasts_PodcastId",
                table: "PodcastProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastProfile_Profiles_Profile_Id",
                table: "PodcastProfile");

            migrationBuilder.DropIndex(
                name: "IX_PodcastProfile_PodcastId",
                table: "PodcastProfile");

            migrationBuilder.DropIndex(
                name: "IX_PodcastProfile_Profile_Id",
                table: "PodcastProfile");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "PodcastProfile");

            migrationBuilder.DropColumn(
                name: "Profile_Id",
                table: "PodcastProfile");
        }
    }
}
