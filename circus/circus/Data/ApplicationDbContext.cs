using circus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace circus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //create tables
        public DbSet<VenueModel> Venues { get; set; }
        public DbSet<PerformerModel> Performers { get; set; }
        public DbSet<ShowModel> Shows { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //venues
            modelBuilder.Entity<VenueModel>().HasData(new VenueModel { Id = 1, Address = "Las Vegas, NV",Name= "Treasure Island", Type="Casino",Image= "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/07/be/34/8d/treasure-island-ti-hotel.jpg?w=900&h=-1&s=1" });
            modelBuilder.Entity<VenueModel>().HasData(new VenueModel { Id = 2, Address = "Las Vegas, NV",Name= "Bellagio", Type="Casino",Image= "https://media-cdn.tripadvisor.com/media/photo-s/1c/8a/e0/b9/bellagio-las-vegas.jpg" });
            //Performer
            modelBuilder.Entity<PerformerModel>().HasData(new PerformerModel {Id=1, Name = "O",Profession="Divers",Image= "https://www.cirquedusoleil.com/-/media/cds/images/shows/o/new/highlights/o_highlights_04_fire_942x570.jpg?h=570&w=942&hash=BE7D8FBFCAF7B9BAD5012DEACED51973D0617C26" });
            modelBuilder.Entity<PerformerModel>().HasData(new PerformerModel {Id=2, Name = "Mystère", Profession= "Acrobatics and dancers", Image = "https://www.cirquedusoleil.com/-/media/cds/images/shows/mystere/new/highlights/mystere_highlights_06_powertrack_942x570.jpg?h=570&w=942&hash=D3183E25FD15F5DD8B95BBBB6A7C3EB93E131D33" });
            //shows
            modelBuilder.Entity<ShowModel>().HasData(new ShowModel { Id = 1, Date = new DateTime(2021, 6, 28, 10, 0, 0), PerformerId = 1, VenueId = 2 });
            modelBuilder.Entity<ShowModel>().HasData(new ShowModel { Id = 2, Date = new DateTime(2021, 7, 1, 10, 0, 0), PerformerId = 2, VenueId = 1 });
        
        
        }
    }
}
