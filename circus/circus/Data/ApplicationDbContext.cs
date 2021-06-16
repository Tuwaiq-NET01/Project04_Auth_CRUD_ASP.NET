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

            //more data
            //venues
            modelBuilder.Entity<VenueModel>().HasData(new VenueModel { Id = 3, Address = "Riviera Maya, Mexico", Name = "Cirque du Soleil", Type = "Theater", Image = "https://i.pinimg.com/originals/c0/dd/f7/c0ddf756d6663523acc138503b23840c.jpg" });
            modelBuilder.Entity<VenueModel>().HasData(new VenueModel { Id = 4, Address = "Hanover, Germany", Name = "ZAG", Type = "Arena", Image = "https://www.hannover.de/var/storage/images/media/01-data-neu/bilder/redaktion-hannover.de/portale/b%C3%BChnen/tui-arena/7060009-1-ger-DE/TUI-Arena.jpg" });
            modelBuilder.Entity<VenueModel>().HasData(new VenueModel { Id = 5, Address = "Rome, Italy", Name = "Tor di Quinto", Type = "Tent", Image = "https://www.eventiculturalimagazine.com/wp-content/uploads/2018/12/mio-20.jpg" });
            //performer
            modelBuilder.Entity<PerformerModel>().HasData(new PerformerModel { Id = 3, Name = "Joyà", Profession = "Performing arts", Image = "https://www.cirquedusoleil.com/-/media/cds/images/shows/joya/highlights/joya_highlights_03_botanik_480x480_2.jpg?db=web&h=480&la=en&vs=1&w=480&hash=80B381B61B5B00159C5B279A50242E1B59DF5EF7" });
            modelBuilder.Entity<PerformerModel>().HasData(new PerformerModel { Id = 4, Name = "Crystal", Profession = "Acrobatics on ice", Image = "https://www.cirquedusoleil.com/-/media/cds/images/shows/crystal/hightlights/thumb/crystal_highlights_01_480x480.jpg?db=web&h=480&la=en&vs=1&w=480&hash=9A360571B39D365B743A539F3F902E57C451122C" });
            modelBuilder.Entity<PerformerModel>().HasData(new PerformerModel { Id = 5, Name = "KURIOS", Profession = "Act", Image = "https://www.cirquedusoleil.com/-/media/cds/images/shows/kurios/highlights_thumbnail/kurios-show-rola-bola.jpg?db=web&h=480&la=en&vs=1&w=480&hash=4E130ABB3F44E29C31D643003A976D77F4098C6A" });
            //show
            modelBuilder.Entity<ShowModel>().HasData(new ShowModel { Id = 3, Date = new DateTime(2021, 8, 4, 11, 0, 0), PerformerId = 3, VenueId = 3 });
            modelBuilder.Entity<ShowModel>().HasData(new ShowModel { Id = 4, Date = new DateTime(2021, 9, 26, 11, 0, 0), PerformerId = 4, VenueId = 4 });
            modelBuilder.Entity<ShowModel>().HasData(new ShowModel { Id = 5, Date = new DateTime(2022, 4, 24, 9, 0, 0), PerformerId = 5, VenueId = 5 });

        }
    }
}
