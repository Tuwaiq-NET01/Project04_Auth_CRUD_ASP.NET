using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Data.Migrations
{
    public partial class MakeRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_desires",
                table: "desires");

            migrationBuilder.RenameTable(
                name: "desires",
                newName: "Desires");

            migrationBuilder.AddColumn<int>(
                name: "LessorId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "Desires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Desires",
                table: "Desires",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Places_LessorId",
                table: "Places",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_RenterId",
                table: "Places",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Desires_RenterId",
                table: "Desires",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desires_Renters_RenterId",
                table: "Desires",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Lessors_LessorId",
                table: "Places",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Renters_RenterId",
                table: "Places",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desires_Renters_RenterId",
                table: "Desires");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Lessors_LessorId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Renters_RenterId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_LessorId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_RenterId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Desires",
                table: "Desires");

            migrationBuilder.DropIndex(
                name: "IX_Desires_RenterId",
                table: "Desires");

            migrationBuilder.DropColumn(
                name: "LessorId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Desires");

            migrationBuilder.RenameTable(
                name: "Desires",
                newName: "desires");

            migrationBuilder.AddPrimaryKey(
                name: "PK_desires",
                table: "desires",
                column: "Id");
        }
    }
}
