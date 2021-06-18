using HealthChoice_Proj4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicesModel> Services { get; set; }
        public DbSet<MembershipsModel> MembberShips { get; set; }

        public DbSet<CommentsModel> Comments { get; set; }
        public DbSet<EventsModel> Events { get; set; }

        public DbSet<FavoriteModel> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<EventsModel>().HasData(new EventsModel { Id = 1, Name = " Race of Champions motorsport event", Date = Convert.ToDateTime("2021-6-1"), Overview= "The motorsport event will be held in the King Fahd International Stadium in Riyadh and is causing great excitement throughout the Kingdom. On the official website of Race of Champions it was announced that this is going to be a family event with activities for everyone.The official statement read: Further details, driver announcements and exact dates for ROC's Saudi Arabian debut will be announced shortly, but the General Sports Authority has confirmed that Race Of Champions will be a family event, open to both genders, and feature drivers, exhibitions and activities all suitable for the Kingdom's specific cultural requirements." , Location= "King Fahd International Stadium in Riyadh", Image= "https://cdn.expatwoman.com/s3fs-public/630601bc-81d3-450a-aabf-c7b68907c1e1.jpg" });
            builder.Entity<EventsModel>().HasData(new EventsModel { Id = 2, Name = "World Boxing Supreme Series Cruiserweight final", Date = Convert.ToDateTime("2020-4-9"), Overview = "Jeddah will be hosting the World Boxing Supreme Series Cruiserweight final in May and spectators will be able to see the two best fighters in the cruiserweight division battle for the title. Local fighters will also have their chance to show off their skills in the ring as a part of the event.", Location = "King Faisal International Stadium in Riyadh", Image = "https://cdn.expatwoman.com/s3fs-public/editorial/iStock-623824284.jpg" });
            builder.Entity<EventsModel>().HasData(new EventsModel { Id = 3, Name = "Riyadh runners enjoy the ‘happiest 5k on the planet’", Date = Convert.ToDateTime("2020-3-23"), Overview = "Held in Saudi Arabia’s capital city Riyadh between March 23 and April 1, The Saudi Games will gather 6,000 female and male athletes expected to participate in 40 sports, including swimming, basketball, athletics, archery. The highest gold medalist prize is set at one million riyals (around USD 266,500), while the second place will receive 300,000 riyals and third place 100,000 riyals. The event will also have some 2,000 technical and administrative supervisors from 13 provinces in the Kingdom.", Location = "Saudi Arabia’s capital city Riyadh", Image = "https://www.arabnews.com/sites/default/files/styles/n_670_395/public/2019/10/26/1817071-205482815.jpg?itok=TC967vOy" });
            base.OnModelCreating(builder);
        }
    }
}
