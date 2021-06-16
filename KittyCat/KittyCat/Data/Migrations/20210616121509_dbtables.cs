using Microsoft.EntityFrameworkCore.Migrations;

namespace KittyCat.Data.Migrations
{
    public partial class dbtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "catTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "0, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "health", "image", "name" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Young", "Domestic Short Hair", "SPICE THEMED MOMMA:  2 years old / small\n\nHi, my name is Anise!  I came to Mostly Mutts from animal...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975818/4/?bust=1623845036&width=600", "Anise" },
                    { 25, 1, 1, 1, "Baby", "Domestic Short Hair", "Santos is a sweet little man. He is 12 weeks old, fixed and vaccinated and looking for his forever home.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975823/1/?bust=1623844812&width=600", "Santos" },
                    { 26, 1, 1, 1, "Baby", "Domestic Short Hair", "Suki is a sweet and loving lady! She is 12 weeks old and spayed/vaccinated", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975822/1/?bust=1623844732&width=600", "Suki" },
                    { 27, 1, 1, 1, "Adult", "Domestic Short Hair", "“Hi, my name is Sabrina! I belonged to a small colony that resided at a mechanic shop. I gave birth...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975819/1/?bust=1623844667&width=600", "Sabrina" },
                    { 28, 1, 1, 1, "Baby", "Domestic Short Hair", "Elena is a sweet little lady. She is playful and outgoing. She loves to be pet and play.\n\nShe is...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975820/1/?bust=1623844640&width=600", "Elena" },
                    { 29, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975811/1/?bust=1623845035&width=600", "Qd Litter Pecan" },
                    { 30, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975809/1/?bust=1623845060&width=600", "Qd Litter Peanutbutter" },
                    { 31, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975810/1/?bust=1623845059&width=600", "Qd Litter Pistashio" },
                    { 32, 1, 1, 1, "Young", "Domestic Short Hair", "Madison and her 4 siblings were born outside in March and rescued in May. She is a little reserved but...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51969350/1/?bust=1623796232&width=600", "Madison" },
                    { 24, 1, 1, 1, "Baby", "Domestic Long Hair", "Han is a bit shy at first, but he loves to be held and is extremely playful. Han is fixed...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975825/1/?bust=1623844958&width=600", "Han" },
                    { 33, 1, 1, 1, "Young", "Domestic Short Hair", "Joey and his siblings were born in March to an outside Mom and thankfully rescued in May. Joey is the...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51969376/2/?bust=1623798161&width=600", "Joey" },
                    { 35, 1, 1, 1, "Adult", "Domestic Long Hair", null, "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975792/1/?bust=1623844537&width=600", "Davey Jones" },
                    { 36, 1, 1, 1, "Baby", "Tabby", "Elmo was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975790/1/?bust=1623843810&width=600", "Elmo" },
                    { 37, 1, 1, 1, "Baby", "Domestic Short Hair", "Cookie Monster was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975787/1/?bust=1623843759&width=600", "Cookie Monster" },
                    { 38, 1, 1, 1, "Young", "Domestic Short Hair", "GREY THEMED MOMMA:  2 years old / small\n\nHello, I&#039;m Haze!  I found myself at animal control nursing three 4-week-old...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975786/1/?bust=1623843712&width=600", "Haze" },
                    { 39, 1, 1, 1, "Baby", "Domestic Short Hair", "Big Bird was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975785/1/?bust=1623843703&width=600", "Big Bird" },
                    { 40, 1, 1, 1, "Baby", "Domestic Short Hair", "Archie was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975782/1/?bust=1623843648&width=600", "Archie" },
                    { 41, 1, 1, 1, "Baby", "Domestic Short Hair", "Abigail was found stray and brought in for adoption.", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975780/1/?bust=1623843593&width=600", "Abigail" },
                    { 42, 1, 1, 1, "Baby", "Domestic Short Hair", "Arlo was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975773/1/?bust=1623843544&width=600", "Arlo" },
                    { 34, 1, 1, 1, "Young", "Domestic Short Hair", "Cocoa and his 4 siblings were born in March outside and rescued in May. He is a quiet sweet boy...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51970085/1/?bust=1623798281&width=600", "Cocoa" },
                    { 23, 1, 1, 1, "Young", "Domestic Short Hair", "SPICE THEMED MOMMA:  2 years old / small\n\nHi, my name is Anise!  I came to Mostly Mutts from animal...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975818/4/?bust=1623845036&width=600", "Anise" },
                    { 22, 1, 1, 1, "Adult", "Domestic Short Hair", "Emma Ruby is a gentle and good nature cat that was taken into rescue by a fellow rescuer when she...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975776/1/?bust=1623844136&width=600", "Emma Ruby" },
                    { 21, 1, 1, 1, "Young", "Domestic Medium Hair", "Beautiful, sweet friendly Samara was living outside and fed by some kind people in Trenton. She gave birth outside and...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975778/1/?bust=1623844167&width=600", "Samara" },
                    { 2, 1, 1, 1, "Baby", "Domestic Long Hair", "Han is a bit shy at first, but he loves to be held and is extremely playful. Han is fixed...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975825/1/?bust=1623844958&width=600", "Han" },
                    { 3, 1, 1, 1, "Baby", "Domestic Short Hair", "Santos is a sweet little man. He is 12 weeks old, fixed and vaccinated and looking for his forever home.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975823/1/?bust=1623844812&width=600", "Santos" },
                    { 4, 1, 1, 1, "Baby", "Domestic Short Hair", "Suki is a sweet and loving lady! She is 12 weeks old and spayed/vaccinated", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975822/1/?bust=1623844732&width=600", "Suki" },
                    { 5, 1, 1, 1, "Adult", "Domestic Short Hair", "“Hi, my name is Sabrina! I belonged to a small colony that resided at a mechanic shop. I gave birth...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975819/1/?bust=1623844667&width=600", "Sabrina" },
                    { 6, 1, 1, 1, "Baby", "Domestic Short Hair", "Elena is a sweet little lady. She is playful and outgoing. She loves to be pet and play.\n\nShe is...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975820/1/?bust=1623844640&width=600", "Elena" },
                    { 7, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975811/1/?bust=1623845035&width=600", "Qd Litter Pecan" },
                    { 8, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975809/1/?bust=1623845060&width=600", "Qd Litter Peanutbutter" },
                    { 9, 1, 1, 1, "Baby", "Tabby", "You can fill out an adoption application online on our official website.If interested in any of our animals for adoption,...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975810/1/?bust=1623845059&width=600", "Qd Litter Pistashio" },
                    { 10, 1, 1, 1, "Young", "Domestic Short Hair", "Madison and her 4 siblings were born outside in March and rescued in May. She is a little reserved but...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51969350/1/?bust=1623796232&width=600", "Madison" },
                    { 11, 1, 1, 1, "Young", "Domestic Short Hair", "Joey and his siblings were born in March to an outside Mom and thankfully rescued in May. Joey is the...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51969376/2/?bust=1623798161&width=600", "Joey" },
                    { 12, 1, 1, 1, "Young", "Domestic Short Hair", "Cocoa and his 4 siblings were born in March outside and rescued in May. He is a quiet sweet boy...", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51970085/1/?bust=1623798281&width=600", "Cocoa" },
                    { 13, 1, 1, 1, "Adult", "Domestic Long Hair", null, "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975792/1/?bust=1623844537&width=600", "Davey Jones" },
                    { 14, 1, 1, 1, "Baby", "Tabby", "Elmo was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975790/1/?bust=1623843810&width=600", "Elmo" },
                    { 15, 1, 1, 1, "Baby", "Domestic Short Hair", "Cookie Monster was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975787/1/?bust=1623843759&width=600", "Cookie Monster" },
                    { 16, 1, 1, 1, "Young", "Domestic Short Hair", "GREY THEMED MOMMA:  2 years old / small\n\nHello, I&#039;m Haze!  I found myself at animal control nursing three 4-week-old...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975786/1/?bust=1623843712&width=600", "Haze" },
                    { 17, 1, 1, 1, "Baby", "Domestic Short Hair", "Big Bird was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975785/1/?bust=1623843703&width=600", "Big Bird" },
                    { 18, 1, 1, 1, "Baby", "Domestic Short Hair", "Archie was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975782/1/?bust=1623843648&width=600", "Archie" },
                    { 19, 1, 1, 1, "Baby", "Domestic Short Hair", "Abigail was found stray and brought in for adoption.", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975780/1/?bust=1623843593&width=600", "Abigail" },
                    { 20, 1, 1, 1, "Baby", "Domestic Short Hair", "Arlo was found stray and brought in for adoption.", "Male", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975773/1/?bust=1623843544&width=600", "Arlo" }
                });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "health", "image", "name" },
                values: new object[] { 43, 1, 1, 1, "Young", "Domestic Medium Hair", "Beautiful, sweet friendly Samara was living outside and fed by some kind people in Trenton. She gave birth outside and...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975778/1/?bust=1623844167&width=600", "Samara" });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "health", "image", "name" },
                values: new object[] { 44, 1, 1, 1, "Adult", "Domestic Short Hair", "Emma Ruby is a gentle and good nature cat that was taken into rescue by a fellow rescuer when she...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/51975776/1/?bust=1623844136&width=600", "Emma Ruby" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "catTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "0, 1");
        }
    }
}
