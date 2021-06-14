using Microsoft.EntityFrameworkCore.Migrations;

namespace Adoption.Data.Migrations
{
    public partial class databaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adopter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "catTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vaccination = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AdopterId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catTable", x => x.id);
                    table.ForeignKey(
                        name: "FK_catTable_adopter_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "adopter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_catTable_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_catTable_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "adopter",
                columns: new[] { "id", "age", "email", "gender", "image", "name", "occupation", "phone" },
                values: new object[,]
                {
                    { 1, 42, "koko@gmail.com", "male", "https://images.unsplash.com/photo-1521119989659-a83eee488004?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=728&q=80", "Ken", null, " 85454995042 " },
                    { 2, 30, "momo@gmail.com", "female", "https://images.unsplash.com/photo-1514448553123-ddc6ee76fd52?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=668&q=80", "Natasha", null, " 46736437743 " }
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "id", "address", "name", "phone" },
                values: new object[,]
                {
                    { 1, "505 broadway st", "Vetsreet", "303849244" },
                    { 2, "404 broadway st", "Pawpatrol", "758348939" },
                    { 3, "303 broadway st", "smartPet", " 7548484844 " }
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "id", "age", "email", "gender", "image", "name", "phone", "reason" },
                values: new object[,]
                {
                    { 1, 24, "roro@gmail.com", "female", "https://images.unsplash.com/photo-1508002366005-75a695ee2d17?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80", "Rose", " 85454995042 ", "relocating" },
                    { 2, 54, "jojo@gmail.com", "male", "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80", "Jack", " 46736437743 ", "relocating" }
                });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "image", "name", "vaccination" },
                values: new object[] { 1, 1, 1, 1, "young", "Domestic Shorthair", "Hi! My name is Kat and I’m an extremely friendly curious and social 1 year old. ( Shy at first of course...;)...)....I’m told I have exotic unique markings with silky coat you can’t even dream of ...;) My ideal home has very affectionate humans who don’t mind my daily exploring. I’m super flirty and love cuddling in with my foster mom in her bed and my siblings as well. If you’re looking for a catTable with a dog personality then I will be your gal. ♥️", "female", "https://pet-uploads.adoptapet.com/6/2/9/547432893.jpg", "Kat", true });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "image", "name", "vaccination" },
                values: new object[] { 2, 1, 2, 1, "young", " Bengal", " They are named Beauregaurd and Antoine. They are the smartest cats I have ever interacted with and and know words and love one another deeply. They are loving yet independent and will play for hours on end with either myself or another. I have an enclosed outdoor space they love to hang out in.", "male", "https://pet-uploads.adoptapet.com/8/b/9/546264169.jpg", "Antoine and Beauregaurd", true });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "image", "name", "vaccination" },
                values: new object[] { 3, 1, 3, 1, "young", "Domestic Shorthair", "Meet the ever-glamorous Elizabeth Taylor.she's 10 months old, like most celebrities, she’s reclusive and prefers a quiet environment. Elizabeth is also very shy and will require someone with patience. However, she is not shy when it’s time for catTable treats! Elizabeth is a strict pescatarian, enjoying the finest fish and seafood. She also enjoys living her best life playing with her favorite toy balls. This exquisite girl has the most beautiful markings with a black whip-like tail and bangs. She is a glamorous girl and is looking for her up upscale forever home.", "female", "https://pet-uploads.adoptapet.com/8/8/f/442558865.jpg", "Elizabeth Taylor", true });

            migrationBuilder.CreateIndex(
                name: "IX_catTable_AdopterId",
                table: "catTable",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_catTable_LocationId",
                table: "catTable",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_catTable_OwnerId",
                table: "catTable",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catTable");

            migrationBuilder.DropTable(
                name: "adopter");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
