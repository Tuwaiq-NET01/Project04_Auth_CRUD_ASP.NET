using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Final_crud_auth.Data.Migrations
{
    public partial class ServicesTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    servId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    servName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.servId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
