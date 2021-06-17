using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeME.Data.Migrations
{
    public partial class altertablewinners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Challenges_ChallengeId",
                table: "Winners");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Comments_CommentId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_CommentId",
                table: "Winners");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Winners");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Winners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Winners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wins",
                table: "Winners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_UserId",
                table: "Winners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_AspNetUsers_UserId",
                table: "Winners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Challenges_ChallengeId",
                table: "Winners",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Winners_AspNetUsers_UserId",
                table: "Winners");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Challenges_ChallengeId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_UserId",
                table: "Winners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Winners");

            migrationBuilder.DropColumn(
                name: "wins",
                table: "Winners");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Winners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Winners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_CommentId",
                table: "Winners",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Challenges_ChallengeId",
                table: "Winners",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Comments_CommentId",
                table: "Winners",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
