using Microsoft.EntityFrameworkCore.Migrations;

namespace TechME_Dashboard.Data.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Trainee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trainee_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Trainee_BIO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Trainee_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Trainee_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainee");
        }
    }
}
