using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenLifeStore.Data.Migrations
{
    public partial class UpdateBranchProductTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProductModel_Branches_BranchId",
                table: "BranchProductModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProductModel_Products_ProductId",
                table: "BranchProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchProductModel",
                table: "BranchProductModel");

            migrationBuilder.RenameTable(
                name: "BranchProductModel",
                newName: "BranchProduct");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProductModel_ProductId",
                table: "BranchProduct",
                newName: "IX_BranchProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchProduct",
                table: "BranchProduct",
                columns: new[] { "BranchId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProduct_Branches_BranchId",
                table: "BranchProduct",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProduct_Products_ProductId",
                table: "BranchProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchProduct_Branches_BranchId",
                table: "BranchProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchProduct_Products_ProductId",
                table: "BranchProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchProduct",
                table: "BranchProduct");

            migrationBuilder.RenameTable(
                name: "BranchProduct",
                newName: "BranchProductModel");

            migrationBuilder.RenameIndex(
                name: "IX_BranchProduct_ProductId",
                table: "BranchProductModel",
                newName: "IX_BranchProductModel_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchProductModel",
                table: "BranchProductModel",
                columns: new[] { "BranchId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProductModel_Branches_BranchId",
                table: "BranchProductModel",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchProductModel_Products_ProductId",
                table: "BranchProductModel",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
