using Microsoft.EntityFrameworkCore.Migrations;

namespace KittyCat.Data.Migrations
{
    public partial class editLocationIdToBeNullAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Dilute Calico", "Tamera was found stray and brought in for adoption.", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008616/1/?bust=1624022690&width=600", "Tamera" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Dilute Calico", "Tia was found stray and brought in for adoption.", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008613/1/?bust=1624022646&width=600", "Tia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Shaw was found stray and brought in for adoption.", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008611/1/?bust=1624022589&width=600", "Shaw" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Hobbs was found stray and brought in for adoption.", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008609/1/?bust=1624022545&width=600", "Hobbs" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Cooper is 8 weeks old. He is a real cutie pie with his tabby patches on his head . Looks...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008562/1/?bust=1624022340&width=600", "Cooper" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Maze is 12 weeks old. \n\nMaze is a playful kitten. She gets along with both dog and kitten siblings. She...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008453/1/?bust=1624020897&width=600", "Maze" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Buttercup is the kitten who feels like a toddler going on a teenager. Almost all play, almost all adventure, a...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008567/1/?bust=1624022430&width=600", "Buttercup" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Blossom is half cuddler &amp;amp; half adventurer. She is assertive in suggesting both to you. She has minimal issues walking...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008568/1/?bust=1624022432&width=600", "Blossom" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Baby", "Bubbles is a cuddle bug and can most often be found sitting on the humans&amp;#39; laps, snuggled in the blankets,...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008566/1/?bust=1624022434&width=600", "Bubbles" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Baby", null, "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008565/1/?bust=1624022429&width=600", "Wendy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Baby", "Domestic Long Hair", "Astro is an 11 week old domestic long hair kitten that is ready for his forever home! The adoption fee...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008481/2/?bust=1624021578&width=600", "Astro" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Hi, I&amp;#39;m Mu Mu. When it comes to relationships, I&amp;#39;m very level-headed. I don&amp;#39;t leap in paws first, if you...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008554/1/?bust=1624022207&width=600", "Mu Mu" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Medium Hair", "Hello! My name is Little Man and I am very excited to find my forever home. I am seeking a...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008553/1/?bust=1624022204&width=600", "Little Man" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Hello! My name is Rudy and I&amp;#39;m the helpful sort! You&amp;#39;re working on the computer? Let me press the keys....", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008550/1/?bust=1624022215&width=600", "Rudy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Domestic Long Hair", "Healthy? Check. Good-Looking? Check. Confident? Check. What more could you ask for in a cat? Augie can provide all of...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008551/1/?bust=1624022207&width=600", "Augie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Ophelia! Heaven help a fool who falls in love, and who wouldn&amp;#39;t fall in love with sweet Ophelia. If you&amp;#39;re...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008552/1/?bust=1624022207&width=600", "Ophelia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Adult", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008549/1/?bust=1624022208&width=600", "Emerald" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008538/1/?bust=1624022214&width=600", "Dandelion" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Baby", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008537/1/?bust=1624022204&width=600", "Dijon" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008540/1/?bust=1624022203&width=600", "Dosa" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Adult", "Domestic Long Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008536/1/?bust=1624022198&width=600", "Priss" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Adult", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008535/1/?bust=1624022195&width=600", "Amos" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "age", "breed", "gender", "image", "name" },
                values: new object[] { "Young", "American Shorthair", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008534/1/?bust=1624022191&width=600", "Lizzy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "Domestic Long Hair", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008522/1/?bust=1624022195&width=600", "Emmett" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "gender", "image", "name" },
                values: new object[] { "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008516/1/?bust=1624022195&width=600", "Betina" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "breed", "image", "name" },
                values: new object[] { "American Shorthair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008519/1/?bust=1624022195&width=600", "Benny" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "description", "image", "name" },
                values: new object[] { null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008528/1/?bust=1624022196&width=600", "Earnest" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Kerby can talk a big game, but he is not as tough as he acts! He has a secret soft...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008530/1/?bust=1624022196&width=600", "Kerby" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "image", "name" },
                values: new object[] { "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008517/1/?bust=1624022196&width=600", "Barney" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "American Shorthair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008526/1/?bust=1624022196&width=600", "Baxter" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "breed", "image", "name" },
                values: new object[] { "Domestic Short Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008521/1/?bust=1624022198&width=600", "Sophia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "Domestic Medium Hair", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008527/1/?bust=1624022192&width=600", "Earline" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Meet Cole, a lovable boy who will make a great pet. Cole enjoys being pet and is ok if you...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008532/1/?bust=1624022192&width=600", "Cole" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Winston is a young man who has not been introduced to the finer things in life quite yet. He has...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008533/1/?bust=1624022193&width=600", "Winston" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "American Shorthair", null, "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008525/1/?bust=1624022193&width=600", "Betty" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "American Shorthair", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008524/1/?bust=1624022194&width=600", "Bo" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Baby", "American Shorthair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008529/1/?bust=1624022193&width=600", "Bob" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "age", "breed", "gender", "image", "name" },
                values: new object[] { "Baby", "American Shorthair", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008520/1/?bust=1624022194&width=600", "Bert" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Desmond is a scared little baby boy that needs a patient and loving family! He has lived his entire life...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008531/1/?bust=1624022195&width=600", "Desmond" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Adult", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008514/3/?bust=1624022192&width=600", "Guy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008513/1/?bust=1624022192&width=600", "Callie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 42,
                columns: new[] { "description", "image", "name" },
                values: new object[] { null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008512/1/?bust=1624022192&width=600", "Ross" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 43,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { null, "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008515/1/?bust=1624022193&width=600", "Bob" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Domestic Long Hair", "Hi, my name is Desiree! I&amp;#39;m two years old and a self-appointed princess. I&amp;#39;m very confident and social, and I...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008509/1/?bust=1624022127&width=600", "Desiree" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 45,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "I&amp;#39;m Zachary and just imagine having to keep up with THREE sisters who all love to run and wrestle and...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008506/1/?bust=1624022139&width=600", "Zachary" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 46,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "This is Darci. Lovable, playful and cuddly! This little girl gets along very well with her two brothers, Darwin &amp;amp;...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008507/1/?bust=1624022140&width=600", "Darci" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 47,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "This is Dalton. Lovable, playful and cuddly! This little guy gets along very well with his brother &amp;amp; sister, as...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008508/1/?bust=1624022145&width=600", "Dalton" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 49,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "This is Darwin. Lovable, playful and cuddly! This little guy gets along very well with his brother &amp;amp; sister, as...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008505/1/?bust=1624022137&width=600", "Darwin" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "I&amp;#39;m Zazie and when foster mom brought us home and opened the carrier door, I was the first one to...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008504/1/?bust=1624022138&width=600", "Zazie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 51,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Zabbie here! Although I may have been the smallest (&amp;#34;runty girl&amp;#34; was my nickname!) in the litter, I have always...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008503/1/?bust=1624022139&width=600", "Zabbie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 52,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "This darling baby girl is Jenni.  She got lost and came to the shelter 6/16.  If not reclaimed she will...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008480/3/?bust=1624021353&width=600", "JENNI available 6/23" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 53,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Primary Color: Tabby Weight: 2.8lbs Age: 0yrs 0mths 10wks Animal has been Neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008488/1/?bust=1624021936&width=600", "Jjj Schmidt" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 54,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Primary Color: Tabby Weight: 2.8lbs Age: 0yrs 0mths 10wks Animal has been Spayed", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008496/1/?bust=1624021930&width=600", "Mary Lou" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 55,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Primary Color: Black Weight: 1.37lbs Age: 0yrs 0mths 7wks Animal has been Spayed", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008498/1/?bust=1624021930&width=600", "Bug" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 56,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", "Primary Color: Grey Weight: 2.3lbs Age: 0yrs 0mths 10wks Animal has been Neutered", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008491/1/?bust=1624021947&width=600", "Berlioz" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 57,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Calypso is a absolutely gorgeous little baby.  So sweet.  He and his twin bonded brother Cree are two SUPER well...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008469/1/?bust=1624021045&width=600", "Calypso  (Bonded to brother Cree)" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 58,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Adult", "Sky - Male Neutered DOB 5/18/2019 Domestic Short Hair Black &amp;amp; White - AVAILABLE TO BE SEEN AT PETSMART ROCHESTER,...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008479/1/?bust=1624021762&width=600", "Sky" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 59,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Tuxedo", "Hi, I&amp;#39;m Sienna (FCID 05/27/2021-69)! I&amp;#39;m a friendly grey and white one-year-old girl with the cutest black smudge on my...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008478/1/?bust=1624022698&width=600", "Sienna (FCID# 05/27/2021- 69 Brookhaven PS) C" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 60,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Olivia &amp; Amanda will be adopted as a pair. They are playful active but a little too young for households...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008438/1/?bust=1624020351&width=600", "Olivia Benson & Amanda Rollins" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 61,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Cree is a absolutely gorgeous little baby.  So sweet.  He and his twin bonded brother Calypso are two SUPER well...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008459/3/?bust=1624020898&width=600", "Cree  (Bonded to brother Calypso)" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 62,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Senior", "DOB: 5-19-13\nFKDS-A-22509\nMicrochip # 981020041671147 Geezer needs a loving home soon! He is a 12 year old boy who...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008466/1/?bust=1624021519&width=600", "Geezer" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 63,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "DOB: 6-1-2016\nMicrochip #: 981020041162627\nID#: FKDS-A-22629 Nala is a cute and petite black female with a white patch on...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008467/1/?bust=1624021522&width=600", "Nala" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 64,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Long Hair", null, "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008465/1/?bust=1624021518&width=600", "Gandalf the Gray" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 65,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Primary Color: Black Secondary Color: White Weight: 6.2lbs Age: 2yrs 0mths 1wks", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008461/1/?bust=1624021476&width=600", "Chanel" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 66,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Adult", "Domestic Short Hair", "Primary Color: Orange Tabby Age: 3yrs 0mths 1wks", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008460/1/?bust=1624021465&width=600", "Bronson" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 67,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Buckminster&#039;s Cat Cafe\nKitten Georgia. We would like to direct you to the teeny tiny black tufts at the tips...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008458/1/?bust=1624020717&width=600", "Georgia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 68,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", "Mercury is a 17 week old domestic short hair kitten that is ready for her forever home! The adoption fee...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008451/2/?bust=1624020617&width=600", "Mercury" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Medium Hair", "Hobbs was found stray and brought in for adoption.", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008609/1/?bust=1624022545&width=600", "Hobbs" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Cooper is 8 weeks old. He is a real cutie pie with his tabby patches on his head . Looks...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008562/1/?bust=1624022340&width=600", "Cooper" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Maze is 12 weeks old. \n\nMaze is a playful kitten. She gets along with both dog and kitten siblings. She...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008453/1/?bust=1624020897&width=600", "Maze" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Buttercup is the kitten who feels like a toddler going on a teenager. Almost all play, almost all adventure, a...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008567/1/?bust=1624022430&width=600", "Buttercup" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Blossom is half cuddler &amp;amp; half adventurer. She is assertive in suggesting both to you. She has minimal issues walking...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008568/1/?bust=1624022432&width=600", "Blossom" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Bubbles is a cuddle bug and can most often be found sitting on the humans&amp;#39; laps, snuggled in the blankets,...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008566/1/?bust=1624022434&width=600", "Bubbles" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "description", "image", "name" },
                values: new object[] { null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008565/1/?bust=1624022429&width=600", "Wendy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Long Hair", "Astro is an 11 week old domestic long hair kitten that is ready for his forever home! The adoption fee...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008481/2/?bust=1624021578&width=600", "Astro" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Adult", "Hi, I&amp;#39;m Mu Mu. When it comes to relationships, I&amp;#39;m very level-headed. I don&amp;#39;t leap in paws first, if you...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008554/1/?bust=1624022207&width=600", "Mu Mu" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Hello! My name is Little Man and I am very excited to find my forever home. I am seeking a...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008553/1/?bust=1624022204&width=600", "Little Man" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Adult", "Domestic Short Hair", "Hello! My name is Rudy and I&amp;#39;m the helpful sort! You&amp;#39;re working on the computer? Let me press the keys....", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008550/1/?bust=1624022215&width=600", "Rudy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Long Hair", "Healthy? Check. Good-Looking? Check. Confident? Check. What more could you ask for in a cat? Augie can provide all of...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008551/1/?bust=1624022207&width=600", "Augie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Ophelia! Heaven help a fool who falls in love, and who wouldn&amp;#39;t fall in love with sweet Ophelia. If you&amp;#39;re...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008552/1/?bust=1624022207&width=600", "Ophelia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { null, "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008549/1/?bust=1624022208&width=600", "Emerald" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", null, "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008538/1/?bust=1624022214&width=600", "Dandelion" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Baby", null, "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008537/1/?bust=1624022204&width=600", "Dijon" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Baby", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008540/1/?bust=1624022203&width=600", "Dosa" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Adult", "Domestic Long Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008536/1/?bust=1624022198&width=600", "Priss" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Adult", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008535/1/?bust=1624022195&width=600", "Amos" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Young", "American Shorthair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008534/1/?bust=1624022191&width=600", "Lizzy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Baby", "Domestic Medium Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008527/1/?bust=1624022192&width=600", "Earline" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Baby", "Meet Cole, a lovable boy who will make a great pet. Cole enjoys being pet and is ok if you...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008532/1/?bust=1624022192&width=600", "Cole" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "age", "breed", "gender", "image", "name" },
                values: new object[] { "Baby", "Domestic Long Hair", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008522/1/?bust=1624022195&width=600", "Emmett" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "American Shorthair", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008516/1/?bust=1624022195&width=600", "Betina" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "gender", "image", "name" },
                values: new object[] { "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008519/1/?bust=1624022195&width=600", "Benny" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "breed", "image", "name" },
                values: new object[] { "Domestic Short Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008528/1/?bust=1624022196&width=600", "Earnest" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Kerby can talk a big game, but he is not as tough as he acts! He has a secret soft...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008530/1/?bust=1624022196&width=600", "Kerby" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "American Shorthair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008517/1/?bust=1624022196&width=600", "Barney" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "image", "name" },
                values: new object[] { "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008526/1/?bust=1624022196&width=600", "Baxter" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Winston is a young man who has not been introduced to the finer things in life quite yet. He has...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008533/1/?bust=1624022193&width=600", "Winston" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "breed", "image", "name" },
                values: new object[] { "American Shorthair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008525/1/?bust=1624022193&width=600", "Betty" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "American Shorthair", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008524/1/?bust=1624022194&width=600", "Bo" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "American Shorthair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008529/1/?bust=1624022193&width=600", "Bob" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "American Shorthair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008520/1/?bust=1624022194&width=600", "Bert" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Desmond is a scared little baby boy that needs a patient and loving family! He has lived his entire life...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008531/1/?bust=1624022195&width=600", "Desmond" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "breed", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008521/1/?bust=1624022198&width=600", "Sophia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "age", "breed", "image", "name" },
                values: new object[] { "Adult", "Domestic Short Hair", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008514/3/?bust=1624022192&width=600", "Guy" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "age", "breed", "gender", "image", "name" },
                values: new object[] { "Adult", "Domestic Short Hair", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008513/1/?bust=1624022192&width=600", "Callie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "description", "image", "name" },
                values: new object[] { null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008512/1/?bust=1624022192&width=600", "Ross" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "age", "image", "name" },
                values: new object[] { "Baby", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008515/1/?bust=1624022193&width=600", "Bob" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Long Hair", "Hi, my name is Desiree! I&amp;#39;m two years old and a self-appointed princess. I&amp;#39;m very confident and social, and I...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008509/1/?bust=1624022127&width=600", "Desiree" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 42,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "I&amp;#39;m Zachary and just imagine having to keep up with THREE sisters who all love to run and wrestle and...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008506/1/?bust=1624022139&width=600", "Zachary" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 43,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "This is Darci. Lovable, playful and cuddly! This little girl gets along very well with her two brothers, Darwin &amp;amp;...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008507/1/?bust=1624022140&width=600", "Darci" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Domestic Short Hair", "This is Dalton. Lovable, playful and cuddly! This little guy gets along very well with his brother &amp;amp; sister, as...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008508/1/?bust=1624022145&width=600", "Dalton" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 45,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "This is Darwin. Lovable, playful and cuddly! This little guy gets along very well with his brother &amp;amp; sister, as...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008505/1/?bust=1624022137&width=600", "Darwin" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 46,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "I&amp;#39;m Zazie and when foster mom brought us home and opened the carrier door, I was the first one to...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008504/1/?bust=1624022138&width=600", "Zazie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 47,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Zabbie here! Although I may have been the smallest (&amp;#34;runty girl&amp;#34; was my nickname!) in the litter, I have always...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008503/1/?bust=1624022139&width=600", "Zabbie" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 49,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "This darling baby girl is Jenni.  She got lost and came to the shelter 6/16.  If not reclaimed she will...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008480/3/?bust=1624021353&width=600", "JENNI available 6/23" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Primary Color: Tabby Weight: 2.8lbs Age: 0yrs 0mths 10wks Animal has been Neutered", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008488/1/?bust=1624021936&width=600", "Jjj Schmidt" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 51,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Primary Color: Tabby Weight: 2.8lbs Age: 0yrs 0mths 10wks Animal has been Spayed", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008496/1/?bust=1624021930&width=600", "Mary Lou" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 52,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Primary Color: Black Weight: 1.37lbs Age: 0yrs 0mths 7wks Animal has been Spayed", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008498/1/?bust=1624021930&width=600", "Bug" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 53,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Primary Color: Grey Weight: 2.3lbs Age: 0yrs 0mths 10wks Animal has been Neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008491/1/?bust=1624021947&width=600", "Berlioz" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 54,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Calypso is a absolutely gorgeous little baby.  So sweet.  He and his twin bonded brother Cree are two SUPER well...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008469/1/?bust=1624021045&width=600", "Calypso  (Bonded to brother Cree)" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 55,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Sky - Male Neutered DOB 5/18/2019 Domestic Short Hair Black &amp;amp; White - AVAILABLE TO BE SEEN AT PETSMART ROCHESTER,...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008479/1/?bust=1624021762&width=600", "Sky" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 56,
                columns: new[] { "age", "breed", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Tuxedo", "Hi, I&amp;#39;m Sienna (FCID 05/27/2021-69)! I&amp;#39;m a friendly grey and white one-year-old girl with the cutest black smudge on my...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008478/1/?bust=1624021758&width=600", "Sienna (FCID# 05/27/2021- 69 Brookhaven PS) C" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 57,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Olivia &amp; Amanda will be adopted as a pair. They are playful active but a little too young for households...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008438/1/?bust=1624020351&width=600", "Olivia Benson & Amanda Rollins" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 58,
                columns: new[] { "age", "description", "image", "name" },
                values: new object[] { "Baby", "Cree is a absolutely gorgeous little baby.  So sweet.  He and his twin bonded brother Calypso are two SUPER well...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008459/3/?bust=1624020898&width=600", "Cree  (Bonded to brother Calypso)" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 59,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Short Hair", "DOB: 6-1-2016\nMicrochip #: 981020041162627\nID#: FKDS-A-22629 Nala is a cute and petite black female with a white patch on...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008467/1/?bust=1624021522&width=600", "Nala" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 60,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Senior", "DOB: 5-19-13\nFKDS-A-22509\nMicrochip # 981020041671147 Geezer needs a loving home soon! He is a 12 year old boy who...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008466/1/?bust=1624021519&width=600", "Geezer" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 61,
                columns: new[] { "breed", "description", "image", "name" },
                values: new object[] { "Domestic Long Hair", null, "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008465/1/?bust=1624021518&width=600", "Gandalf the Gray" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 62,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Adult", "Primary Color: Black Secondary Color: White Weight: 6.2lbs Age: 2yrs 0mths 1wks", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008461/1/?bust=1624021476&width=600", "Chanel" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 63,
                columns: new[] { "description", "gender", "image", "name" },
                values: new object[] { "Primary Color: Orange Tabby Age: 3yrs 0mths 1wks", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008460/1/?bust=1624021465&width=600", "Bronson" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 64,
                columns: new[] { "breed", "description", "gender", "image", "name" },
                values: new object[] { "Domestic Short Hair", "Buckminster&#039;s Cat Cafe\nKitten Georgia. We would like to direct you to the teeny tiny black tufts at the tips...", "Female", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008458/1/?bust=1624020717&width=600", "Georgia" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 65,
                columns: new[] { "age", "description", "gender", "image", "name" },
                values: new object[] { "Baby", "Mercury is a 17 week old domestic short hair kitten that is ready for her forever home! The adoption fee...", "Male", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008451/2/?bust=1624020617&width=600", "Mercury" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 66,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Senior", "Maine Coon", "Meet Blue\nBlue is incredibly handsome and got his name because of his gorgeous blue eyes, which standout against his...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008449/1/?bust=1624020551&width=600", "Blue" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 67,
                columns: new[] { "description", "image", "name" },
                values: new object[] { "Meet this beautiful gal named Ally! She came into the shelter with her mom Sarah as strays on April 7,...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008432/2/?bust=1624020229&width=600", "Ally" });

            migrationBuilder.UpdateData(
                table: "catTable",
                keyColumn: "id",
                keyValue: 68,
                columns: new[] { "age", "breed", "description", "image", "name" },
                values: new object[] { "Senior", "Domestic Medium Hair", "Say hello to Scampi. He is a sweet, affectionate 14-year-old male domestic medium hair cat and he is housed in...", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008400/1/?bust=1624020068&width=600", "Scampi" });

            migrationBuilder.InsertData(
                table: "catTable",
                columns: new[] { "id", "AdopterId", "LocationId", "OwnerId", "age", "breed", "description", "gender", "health", "image", "name" },
                values: new object[,]
                {
                    { 70, 1, 1, 1, "Young", "Domestic Short Hair", "Belle was dropped outside of Belle Fourche and the folks who found her can&#039;t keep her, would like to rehome...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008426/1/?bust=1624020298&width=600", "Belle" },
                    { 69, 1, 1, 1, "Adult", "Domestic Short Hair", "Tippy is approximately 2 years old.  She is friendly, but would probably do best in a home without very young...", "Female", "spayed_neutered", "https://dl5zpyw5k3jeb.cloudfront.net/photos/pets/52008443/1/?bust=1624022547&width=600", "Tippy" }
                });
        }
    }
}
