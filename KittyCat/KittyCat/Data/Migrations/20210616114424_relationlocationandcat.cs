using Microsoft.EntityFrameworkCore.Migrations;

namespace KittyCat.Data.Migrations
{
    public partial class relationlocationandcat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_location_catTable_catid",
                table: "location");

            migrationBuilder.DropIndex(
                name: "IX_location_catid",
                table: "location");

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "catid",
                table: "location");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "catTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_catTable_LocationId",
                table: "catTable",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_catTable_location_LocationId",
                table: "catTable",
                column: "LocationId",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catTable_location_LocationId",
                table: "catTable");

            migrationBuilder.DropIndex(
                name: "IX_catTable_LocationId",
                table: "catTable");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "catTable");

            migrationBuilder.AddColumn<int>(
                name: "catid",
                table: "location",
                type: "int",
                nullable: true);

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
                name: "IX_location_catid",
                table: "location",
                column: "catid");

            migrationBuilder.AddForeignKey(
                name: "FK_location_catTable_catid",
                table: "location",
                column: "catid",
                principalTable: "catTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
