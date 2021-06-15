using Microsoft.EntityFrameworkCore.Migrations;

namespace KittyCat.Data.Migrations
{
    public partial class seedingapi : Migration
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
                    health = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AdopterId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_catTable_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                    table.ForeignKey(
                        name: "FK_location_catTable_catid",
                        column: x => x.catid,
                        principalTable: "catTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "id", "address", "catid", "name", "phone" },
                values: new object[,]
                {
                    { 1, "505 broadway st", null, "Vetsreet", "303849244" },
                    { 2, "404 broadway st", null, "Pawpatrol", "758348939" },
                    { 3, "303 broadway st", null, "smartPet", " 7548484844 " }
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
                columns: new[] { "id", "AdopterId", "OwnerId", "age", "breed", "description", "gender", "health", "image", "name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Senior", "American Shorthair", "* Little bear will be spayed/neutered on June 18, 2021. Then we Will be positive of gender. We are currently...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961594/1/?bust=1623774607&width=600", "Little Bear" },
                    { 28, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962154/1/?bust=1623774815&width=600", "Rizzo" },
                    { 27, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962160/1/?bust=1623774846&width=600", "Miss Piggy" },
                    { 26, 1, 1, "Baby", "Domestic Short Hair", "Mavis loves being held like a baby, she is very cuddly and sweet. She can also be energetic and playful....", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961612/4/?bust=1623774703&width=600", "Mavis" },
                    { 25, 1, 1, "Senior", "American Shorthair", "* Little bear will be spayed/neutered on June 18, 2021. Then we Will be positive of gender. We are currently...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961594/1/?bust=1623774607&width=600", "Little Bear" },
                    { 24, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961641/1/?bust=1623774733&width=600", "Kermit" },
                    { 23, 1, 1, "Baby", "Tuxedo", "Very friendly, sweet, playful", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961640/1/?bust=1623774783&width=600", "Moo cow" },
                    { 22, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962154/1/?bust=1623774815&width=600", "Rizzo" },
                    { 21, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962160/1/?bust=1623774846&width=600", "Miss Piggy" },
                    { 20, 1, 1, "Baby", "Domestic Short Hair", "Mavis loves being held like a baby, she is very cuddly and sweet. She can also be energetic and playful....", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961612/4/?bust=1623774703&width=600", "Mavis" },
                    { 19, 1, 1, "Senior", "American Shorthair", "* Little bear will be spayed/neutered on June 18, 2021. Then we Will be positive of gender. We are currently...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961594/1/?bust=1623774607&width=600", "Little Bear" },
                    { 18, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961641/1/?bust=1623774733&width=600", "Kermit" },
                    { 17, 1, 1, "Baby", "Tuxedo", "Very friendly, sweet, playful", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961640/1/?bust=1623774783&width=600", "Moo cow" },
                    { 16, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962154/1/?bust=1623774815&width=600", "Rizzo" },
                    { 15, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962160/1/?bust=1623774846&width=600", "Miss Piggy" },
                    { 14, 1, 1, "Baby", "Domestic Short Hair", "Mavis loves being held like a baby, she is very cuddly and sweet. She can also be energetic and playful....", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961612/4/?bust=1623774703&width=600", "Mavis" },
                    { 13, 1, 1, "Senior", "American Shorthair", "* Little bear will be spayed/neutered on June 18, 2021. Then we Will be positive of gender. We are currently...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961594/1/?bust=1623774607&width=600", "Little Bear" },
                    { 12, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961641/1/?bust=1623774733&width=600", "Kermit" },
                    { 11, 1, 1, "Baby", "Tuxedo", "Very friendly, sweet, playful", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961640/1/?bust=1623774783&width=600", "Moo cow" },
                    { 10, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962154/1/?bust=1623774815&width=600", "Rizzo" },
                    { 9, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962160/1/?bust=1623774846&width=600", "Miss Piggy" },
                    { 8, 1, 1, "Baby", "Domestic Short Hair", "Mavis loves being held like a baby, she is very cuddly and sweet. She can also be energetic and playful....", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961612/4/?bust=1623774703&width=600", "Mavis" },
                    { 7, 1, 1, "Senior", "American Shorthair", "* Little bear will be spayed/neutered on June 18, 2021. Then we Will be positive of gender. We are currently...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961594/1/?bust=1623774607&width=600", "Little Bear" },
                    { 6, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961641/1/?bust=1623774733&width=600", "Kermit" },
                    { 5, 1, 1, "Baby", "Tuxedo", "Very friendly, sweet, playful", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961640/1/?bust=1623774783&width=600", "Moo cow" },
                    { 4, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962154/1/?bust=1623774815&width=600", "Rizzo" },
                    { 3, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51962160/1/?bust=1623774846&width=600", "Miss Piggy" },
                    { 2, 1, 1, "Baby", "Domestic Short Hair", "Mavis loves being held like a baby, she is very cuddly and sweet. She can also be energetic and playful....", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961612/4/?bust=1623774703&width=600", "Mavis" },
                    { 29, 1, 1, "Baby", "Tuxedo", "Very friendly, sweet, playful", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961640/1/?bust=1623774783&width=600", "Moo cow" },
                    { 30, 1, 1, "Adult", "Domestic Short Hair", "We are scheduling appointments for potential adopters to call and discuss the kitten or cat of interest with an adoption...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51961641/1/?bust=1623774733&width=600", "Kermit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_catTable_AdopterId",
                table: "catTable",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_catTable_OwnerId",
                table: "catTable",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_location_catid",
                table: "location",
                column: "catid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "catTable");

            migrationBuilder.DropTable(
                name: "adopter");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
