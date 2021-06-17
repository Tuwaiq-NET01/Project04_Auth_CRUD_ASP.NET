using Microsoft.EntityFrameworkCore.Migrations;

namespace Events_Hall.Data.Migrations
{
    public partial class addedEventSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PresentorName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "Duration", "HallId", "Image", "Name", "PresentorId", "PresentorName", "Time" },
                values: new object[,]
                {
                    { 1, "To lose our jobs to our future supreme AI overlords ... or to not? That's the question (and we have some surprising answers).", "2 Hours", 3, "https://pi.tedcdn.com/r/talkstar-assets.s3.amazonaws.com/production/playlists/playlist_642/2437dd5f-4efd-40e9-a417-8c9d879ac9ea/What-happens-after-robots-take-our-jobs_1200x627+(1).jpg?quality=89&w=1200", "What happens when the robots take our jobs?", 1, "Sameera Alhussainy", "Friday, June 4, 2021 8:30:00 PM" },
                    { 2, "In 2014, the world avoided a global outbreak of Ebola, thanks to thousands of selfless health workers -- plus, frankly, some very good luck. In hindsight, we know what we should have done better. So, now's the time, MJ suggests, to put all our good ideas into practice, from scenario planning to vaccine research to health worker training. As he says, There's no need to panic ... but we need to get going.", "3 Hours", 2, "https://www.gard.no/Content/29112072/cache=20203101143212/Coronavirus_people.jpg", "The Next Outbreak? We're Not Ready", 3, "Michael Jackson", "Friday, August 1, 2021 7:30:00 PM" },
                    { 3, "Reema Alyousef knows that procrastination doesn't make sense, but she's never been able to shake her habit of waiting until the last minute to get things done. In this hilarious and insightful talk, Reema takes us on a journey through YouTube binges, Gaming rabbit holes and bouts of staring out the window -- and encourages us to think harder about what we're really procrastinating on, before we run out of time.", "3 Hours", 1, "https://cdn.substack.com/image/fetch/f_auto,q_auto:good,fl_progressive:steep/https%3A%2F%2Fbucketeer-e05bbc84-baa3-437e-9518-adb32be77984.s3.amazonaws.com%2Fpublic%2Fimages%2F3586ad3c-6847-457a-ba75-b3f5d4e6d46a_1920x1080.png", "Inside the Mind of a Master Procrastinator", 6, "Reema Alyousef", "Friday, August 16, 2021 6:30:00 PM" },
                    { 4, "Hala Alyousef admits she won a genetic lottery: she's tall, pretty and a high fashion model. But don't judge her by her looks. In this fearless talk, she takes a wry look at the industry that had her looking highly seductive at barely 16 years old.", "2 Hours", 2, "https://images.artland.com/eyJidWNrZXQiOiJhcnRsYW5kLXVwbG9hZHMiLCJrZXkiOiJnYWxsZXJpZXMvY2p6NnZrYm94MTdibjA3OTF1eHF5NzdmZy9hcnR3b3Jrcy9ja21leTg3bXkwMDJzMmVzZWN0OHpjdmJrL2Y5MmVjMjMwLTdhNzAtNDgwYi1hNTRhLTFkNTgwZjE2ZDJhNC5qcGVnIiwiZWRpdHMiOnsianBlZyI6eyJxdWFsaXR5Ijo4MH0sInJvdGF0ZSI6bnVsbCwicmVzaXplIjp7IndpZHRoIjo2MDAsImhlaWdodCI6NjAwLCJmaXQiOiJpbnNpZGUifX19", "Looks aren't everything, Believe Me. I'm a Model", 5, "Hala Alyousef", "Tuesday, July 1, 2021 2:30:00 PM" },
                    { 5, "In a culture where being social and outgoing are prized above all else, it can be difficult, even shameful, to be an introvert. But, as Steven argues in this passionate talk, introverts bring extraordinary talents and abilities to the world, and should be encouraged and celebrated.", "2 Hours", 2, "https://i.insider.com/53eccec469beddaa722af1d8?width=1000&format=jpeg&auto=webp", "The Power of Introverts", 4, "Steven Hawking", "Monday, July 22, 2021 9:00:00 PM" },
                    { 6, "Elon Musk discusses his new project digging tunnels under LA, the latest from Tesla and SpaceX and his motivation for building a future on Mars in conversation with TED's Head Curator, Chris Anderson.", "1 Hour", 3, "https://www.incimages.com/uploaded_files/image/1920x1080/ElonMusk-CourtesyofMikeFemiaTED_196726.jpg", "The Future We're Building — and Boring", 2, "Elon Musk", "Friday, September 20, 2021 3:00:00 PM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "PresentorName",
                table: "Events");
        }
    }
}
