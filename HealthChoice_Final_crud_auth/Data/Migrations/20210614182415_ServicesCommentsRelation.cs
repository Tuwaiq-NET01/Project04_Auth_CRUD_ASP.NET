using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class ServicesCommentsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Services_ServiceservId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServiceservId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServiceservId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "servId",
                table: "Services",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "Comments",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "comId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Services_ServiceId",
                table: "Comments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Services_ServiceId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Services",
                newName: "servId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Comments",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "comId");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceID",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServiceservId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceservId",
                table: "Comments",
                column: "ServiceservId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Services_ServiceservId",
                table: "Comments",
                column: "ServiceservId",
                principalTable: "Services",
                principalColumn: "servId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
