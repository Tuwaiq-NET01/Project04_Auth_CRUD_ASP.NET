using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthChoice_Proj4.Data.Migrations
{
    public partial class EventsUpdationgData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Image", "Location", "Name", "Overview" },
                values: new object[] { new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.expatwoman.com/s3fs-public/630601bc-81d3-450a-aabf-c7b68907c1e1.jpg", "King Fahd International Stadium in Riyadh", " Race of Champions motorsport event", "The motorsport event will be held in the King Fahd International Stadium in Riyadh and is causing great excitement throughout the Kingdom. On the official website of Race of Champions it was announced that this is going to be a family event with activities for everyone.The official statement read: Further details, driver announcements and exact dates for ROC's Saudi Arabian debut will be announced shortly, but the General Sports Authority has confirmed that Race Of Champions will be a family event, open to both genders, and feature drivers, exhibitions and activities all suitable for the Kingdom's specific cultural requirements." });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Location", "Name", "Overview" },
                values: new object[] { "https://cdn.expatwoman.com/s3fs-public/editorial/iStock-623824284.jpg", "King Faisal International Stadium in Riyadh", "World Boxing Supreme Series Cruiserweight final", "Jeddah will be hosting the World Boxing Supreme Series Cruiserweight final in May and spectators will be able to see the two best fighters in the cruiserweight division battle for the title. Local fighters will also have their chance to show off their skills in the ring as a part of the event." });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Image", "Location", "Name", "Overview" },
                values: new object[] { 3, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.arabnews.com/sites/default/files/styles/n_670_395/public/2019/10/26/1817071-205482815.jpg?itok=TC967vOy", "Saudi Arabia’s capital city Riyadh", "Riyadh runners enjoy the ‘happiest 5k on the planet’", "Held in Saudi Arabia’s capital city Riyadh between March 23 and April 1, The Saudi Games will gather 6,000 female and male athletes expected to participate in 40 sports, including swimming, basketball, athletics, archery. The highest gold medalist prize is set at one million riyals (around USD 266,500), while the second place will receive 300,000 riyals and third place 100,000 riyals. The event will also have some 2,000 technical and administrative supervisors from 13 provinces in the Kingdom." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Image", "Location", "Name", "Overview" },
                values: new object[] { new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRW3B-BS2WusiV3saTLR6geS3arZRqonNxsBl4PrmunO34ndoXNNq_feMD3_ir62-6My-A&usqp=CAU", "Madinah", "Ezz Events", "Creative apps" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Location", "Name", "Overview" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9nRLwpIt897OeK8n3DCj7l1VCFEGtf2p8jU2fE0wgYLmfQ60KlY1SVYbMDwq96vv6tM&usqp=CAU", "Raif", "Samirah Events", "Creative apps" });
        }
    }
}
