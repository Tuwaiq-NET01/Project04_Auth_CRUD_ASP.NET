using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStore.Migrations
{
    public partial class RenameRatingsAppsCtegoriesTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategoryModel_Apps_AppId",
                table: "AppCategoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCategoryModel_Categories_CategoryId",
                table: "AppCategoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingModel_Apps_AppId",
                table: "RatingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingModel_AspNetUsers_UserId",
                table: "RatingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingModel",
                table: "RatingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCategoryModel",
                table: "AppCategoryModel");

            migrationBuilder.RenameTable(
                name: "RatingModel",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "AppCategoryModel",
                newName: "AppsCategories");

            migrationBuilder.RenameIndex(
                name: "IX_RatingModel_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingModel_AppId",
                table: "Ratings",
                newName: "IX_Ratings_AppId");

            migrationBuilder.RenameIndex(
                name: "IX_AppCategoryModel_CategoryId",
                table: "AppsCategories",
                newName: "IX_AppsCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AppCategoryModel_AppId",
                table: "AppsCategories",
                newName: "IX_AppsCategories_AppId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppsCategories",
                table: "AppsCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppsCategories_Apps_AppId",
                table: "AppsCategories",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppsCategories_Categories_CategoryId",
                table: "AppsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Apps_AppId",
                table: "Ratings",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppsCategories_Apps_AppId",
                table: "AppsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AppsCategories_Categories_CategoryId",
                table: "AppsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Apps_AppId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppsCategories",
                table: "AppsCategories");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "RatingModel");

            migrationBuilder.RenameTable(
                name: "AppsCategories",
                newName: "AppCategoryModel");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "RatingModel",
                newName: "IX_RatingModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_AppId",
                table: "RatingModel",
                newName: "IX_RatingModel_AppId");

            migrationBuilder.RenameIndex(
                name: "IX_AppsCategories_CategoryId",
                table: "AppCategoryModel",
                newName: "IX_AppCategoryModel_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AppsCategories_AppId",
                table: "AppCategoryModel",
                newName: "IX_AppCategoryModel_AppId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingModel",
                table: "RatingModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCategoryModel",
                table: "AppCategoryModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategoryModel_Apps_AppId",
                table: "AppCategoryModel",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategoryModel_Categories_CategoryId",
                table: "AppCategoryModel",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingModel_Apps_AppId",
                table: "RatingModel",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingModel_AspNetUsers_UserId",
                table: "RatingModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
