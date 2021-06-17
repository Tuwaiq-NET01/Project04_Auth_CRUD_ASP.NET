using Events_Hall.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Hall.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Event_AttendeeModel>()
                .HasKey(cc => new { cc.HeroId, cc.MovieId });*/
            modelBuilder.Entity<Event_AttendeeModel>()
                .HasOne(a => a.Attendee)
                .WithMany(ae => ae.Event_Attendee)
                .HasForeignKey(aei => aei.AttendeeId);
            modelBuilder.Entity<Event_AttendeeModel>()
                .HasOne(a => a.Event)
                .WithMany(ae => ae.Event_Attendee)
                .HasForeignKey(aei => aei.EventId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HallModel>().HasData(new HallModel { Id = 1, Capacity = 50, Name = "First Venue", Avaliability = true });
            modelBuilder.Entity<HallModel>().HasData(new HallModel { Id = 2, Capacity = 200, Name = "Main Hall", Avaliability = false });
            modelBuilder.Entity<HallModel>().HasData(new HallModel { Id = 3, Capacity = 1000, Name = "Conference Hall ", Avaliability = true });

            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 1, Name = "Sameera Alhussainy", Email = "spurofthemoment@gmail.com", Phone = 0556110112, Field = "IT" });
            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 2, Name = "Elon Musk", Email = "ceo@tesla.com", Phone = 0556123123, Field = "Business" });
            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 3, Name = "Michael Jackson", Email = "mj@gmail.com", Phone = 0522666987, Field = "Health" });
            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 4, Name = "Steven Hawking", Email = "steven@galaxybrain.com", Phone = 0598644222, Field = "Science" });
            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 5, Name = "Hala Alyousef", Email = "hala@galaxybrain.com", Phone = 0522441234, Field = "Bullshit" });
            modelBuilder.Entity<PresentorModel>().HasData(new PresentorModel { Id = 6, Name = "Reema Alyousef", Email = "reema@galaxybrain.com", Phone = 0547722199, Field = "Divine Philosophy" });

            modelBuilder.Entity<AttendeeModel>().HasData(new AttendeeModel { Id = 1, Name = "Reema Alyousef", Email = "reema@gmail.com", Phone = 0547722199, Field = "IT",EventId=1 });
            modelBuilder.Entity<AttendeeModel>().HasData(new AttendeeModel { Id = 2, Name = "Hala Alyousef", Email = "hala@gmail.com", Phone = 0554124771, Field = "Business", EventId = 3});
            modelBuilder.Entity<AttendeeModel>().HasData(new AttendeeModel { Id = 3, Name = "Dorrah Alsaad", Email = "durrdurr@gmail.com", Phone = 0532121731, Field = "Marketing",EventId = 3 });

            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 1,
                Name = "What happens when the robots take our jobs?",
                Time = "Friday, June 4, 2021 8:30:00 PM",
                Duration = "2 Hours",
                PresentorId = 1,


                Image = "https://pi.tedcdn.com/r/talkstar-assets.s3.amazonaws.com/production/playlists/playlist_642/2437dd5f-4efd-40e9-a417-8c9d879ac9ea/What-happens-after-robots-take-our-jobs_1200x627+(1).jpg?quality=89&w=1200",
                HallId = 3,
                Description = "To lose our jobs to our future supreme AI overlords ... or to not? That's the question (and we have some surprising answers).",
                PresentorName = "Sameera Alhussainy"
            });
            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 2,
                Name = "The Next Outbreak? We're Not Ready",
                Time = "Friday, August 1, 2021 7:30:00 PM",
                Duration = "3 Hours",
                PresentorId = 3,
                Image = "https://www.gard.no/Content/29112072/cache=20203101143212/Coronavirus_people.jpg",
                HallId = 2,
                Description = "In 2014, the world avoided a global outbreak of Ebola, thanks to thousands of selfless health workers -- plus, frankly, some very good luck. In hindsight, we know what we should have done better. So, now's the time, MJ suggests, to put all our good ideas into practice, from scenario planning to vaccine research to health worker training. As he says, There's no need to panic ... but we need to get going.",
                PresentorName = "Michael Jackson"
            });

            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 3,
                Name = "Inside the Mind of a Master Procrastinator",
                Time = "Friday, August 16, 2021 6:30:00 PM",
                Duration = "3 Hours",
                PresentorId = 6,
                Image = "https://cdn.substack.com/image/fetch/f_auto,q_auto:good,fl_progressive:steep/https%3A%2F%2Fbucketeer-e05bbc84-baa3-437e-9518-adb32be77984.s3.amazonaws.com%2Fpublic%2Fimages%2F3586ad3c-6847-457a-ba75-b3f5d4e6d46a_1920x1080.png",
                HallId = 1,
                Description = "Reema Alyousef knows that procrastination doesn't make sense, but she's never been able to shake her habit of waiting until the last minute to get things done. In this hilarious and insightful talk, Reema takes us on a journey through YouTube binges, Gaming rabbit holes and bouts of staring out the window -- and encourages us to think harder about what we're really procrastinating on, before we run out of time.",
                PresentorName = "Reema Alyousef"
            });

            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 4,
                Name = "Looks aren't everything, Believe Me. I'm a Model",
                Time = "Tuesday, July 1, 2021 2:30:00 PM",
                Duration = "2 Hours",
                PresentorId = 5,
                Image = "https://images.artland.com/eyJidWNrZXQiOiJhcnRsYW5kLXVwbG9hZHMiLCJrZXkiOiJnYWxsZXJpZXMvY2p6NnZrYm94MTdibjA3OTF1eHF5NzdmZy9hcnR3b3Jrcy9ja21leTg3bXkwMDJzMmVzZWN0OHpjdmJrL2Y5MmVjMjMwLTdhNzAtNDgwYi1hNTRhLTFkNTgwZjE2ZDJhNC5qcGVnIiwiZWRpdHMiOnsianBlZyI6eyJxdWFsaXR5Ijo4MH0sInJvdGF0ZSI6bnVsbCwicmVzaXplIjp7IndpZHRoIjo2MDAsImhlaWdodCI6NjAwLCJmaXQiOiJpbnNpZGUifX19"
                , HallId = 2,
                Description = "Hala Alyousef admits she won a genetic lottery: she's tall, pretty and a high fashion model. But don't judge her by her looks. In this fearless talk, she takes a wry look at the industry that had her looking highly seductive at barely 16 years old.",
                PresentorName = "Hala Alyousef"
            });

            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 5,
                Name = "The Power of Introverts",
                Time = "Monday, July 22, 2021 9:00:00 PM",
                Duration = "2 Hours"
                ,
                PresentorId = 4,
                Image = "https://i.insider.com/53eccec469beddaa722af1d8?width=1000&format=jpeg&auto=webp",
                HallId = 2,
                Description = "In a culture where being social and outgoing are prized above all else, it can be difficult, even shameful, to be an introvert. But, as Steven argues in this passionate talk, introverts bring extraordinary talents and abilities to the world, and should be encouraged and celebrated.",
                PresentorName= "Steven Hawking"
            });

            modelBuilder.Entity<EventModel>().HasData(new EventModel
            {
                Id = 6,
                Name = "The Future We're Building — and Boring",
                Time = "Friday, September 20, 2021 3:00:00 PM",
                Duration = "1 Hour"
                ,
                PresentorId = 2,
                Image = "https://www.incimages.com/uploaded_files/image/1920x1080/ElonMusk-CourtesyofMikeFemiaTED_196726.jpg",
                HallId = 3,
                Description = "Elon Musk discusses his new project digging tunnels under LA, the latest from Tesla and SpaceX and his motivation for building a future on Mars in conversation with TED's Head Curator, Chris Anderson.",
                PresentorName = "Elon Musk"
            });

            modelBuilder.Entity<Event_AttendeeModel>().HasData(new Event_AttendeeModel{Id = 1, AttendeeId=1, EventId=1});
            modelBuilder.Entity<Event_AttendeeModel>().HasData(new Event_AttendeeModel { Id = 3, AttendeeId = 2, EventId = 3 });
            modelBuilder.Entity<Event_AttendeeModel>().HasData(new Event_AttendeeModel { Id = 4, AttendeeId = 3, EventId = 3 });

        }

        public DbSet<EventModel> Events { get; set; }

        public DbSet<HallModel> Halls { get; set; }

        public DbSet<PresentorModel> Presentors { get; set; }

        public DbSet<AttendeeModel> Attendees { get; set; }

        public DbSet<Event_AttendeeModel> Event_Attendee { get; set; }
    }
}
