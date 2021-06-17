using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ConferenceRoomManager.Models;

namespace ConferenceRoomManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<BuildingModel> Buildings { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<FacilityModel> Facilities { get; set; }



        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 1,
                    Name = "Green Bar"
                });
            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 2,
                    Name = "Starbucks"
                });
            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 3,
                    Name = "Costa coffee"
                });
            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 4,
                    Name = "Pret a Manger"
                });
            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 5,
                    Name = "Highfield Pharmacy"
                });
            modelBuilder.Entity<FacilityModel>().HasData(
                new FacilityModel
                {
                    Id = 6,
                    Name = "Terrace Restaurant"
                });

            //seeding
            modelBuilder.Entity<BuildingModel>().HasData(
                new BuildingModel
                {
                    Id = 1,
                    Name = "B12",
                    Description = "Houses The Hartley Library, IT Soultions, Study rooms, and many Facilities",
                    Image = "https://www.southampton.ac.uk/sites/default/files/styles/banner_medium/public/2020-06/aerial-view-highfield-sunny-day.jpg?h=2e5cdddf&itok=0yzClUVO",
                    Location = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJW_B-i_ZzdEgR6xjnALzwrgY&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk"
                });
            modelBuilder.Entity<BuildingModel>().HasData(
                new BuildingModel
                {
                    Id = 2,
                    Name = "B53",
                    Description = "New Mountbatten contains the following: School of Electronics & Computer Science. Physical Sciences and Engineering. Optoelectronics Research Centre. Comms, Signal Processing & Control ORC. Research ORC & Enterprise. Technical Support Staff. NANO. Electronic & Software Systems",
                    Image = "https://www.zeplerinstitute.com/sites/www.zeplerinstitute.ac.uk/files/zepler_exterior_2_0.jpg",
                    Location = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJW_jlkvVzdEgRP4M0dE0Zozo&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk"
                });
            modelBuilder.Entity<BuildingModel>().HasData(
                new BuildingModel
                {
                    Id = 3,
                    Name = "B100",
                    Description = "The Centenary Building also has an 80-seat Harvard lecture theatre, numerous private pod study spaces, bookable seminar rooms and large flat floored teaching spaces.",
                    Image = "https://pbs.twimg.com/media/EUV6_ypWkAAzhl4.jpg",
                    Location = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJhbfAkaBzdEgRii3AIRj1Qp4&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk"
                });
            modelBuilder.Entity<BuildingModel>().HasData(
                new BuildingModel
                {
                    Id = 4,
                    Name = "B178",
                    Description = "Home to our engineering and maritime engineering courses and has a number of world-class testing and research laboratories.",
                    Image = "https://www.bof.co.uk/assets/images/projects/University-of-Southampton-B178-Boldrewood/boldrewood-small-1.png",
                    Location = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJe-3X6vVzdEgR9urRdV4flj4&key=AIzaSyBWPgMGItsQRc2AQdFXfIgQs_QmV0tiCvk"
                });


            //seeding 

            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 1,
                    Name = "Study",
                    Description = "Personal study space.",
                    Capacity = 1,
                    BuildingId = 1,
                    FacilityId = 3,
                    Image = "https://www.southampton.ac.uk/sites/default/files/styles/block_card_image_small/public/2020-07/students-studying-pods_0.jpg"
                });
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 2,
                    Name = "Lab",
                    Description = "Large rooms.",
                    Capacity = 76,
                    BuildingId = 2,
                    FacilityId = 1,
                    Image = "https://lh3.googleusercontent.com/proxy/m5EIKPse4yZo71SAdNQhr-MsQeRIHCVr506uQxCvMFIeFsUtBNeDAcgT0uvrda0gUj7Rfa84CkzjT6-zStm1WoWnh0TZvoJ_RisgnPH7lPI8zJQzZgIEcAHdlzJxESxwHP2QGjjBkJ8UAsHPU4ULHTVnwFkSHdsL7diXAsKNm0nZt_iGmDTlws2ZhuBQsu9rjOFUfynooXUaQIx1xPQ4_6L5hbKcP572ePFfW5qXjr29Pz606Q"
                });
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 3,
                    Name = "Study",
                    Description = "Large study rooms.",
                    Capacity = 100,
                    BuildingId = 3,
                    FacilityId = 2,
                    Image = "https://cdn.southampton.ac.uk/assets/imported/transforms/site/slideshow/Media_Img/BC294B5E657C498A82D61D1F7AACD905/Study%20space%20and%20views.jpg_SIA_JPG_fit_to_width_XL.jpg"
                });
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 4,
                    Name = "Lab",
                    Description = "Large lab and advanced equipments.",
                    Capacity = 150,
                    BuildingId = 2,
                    FacilityId = 4,
                    Image = "https://www.tlc-business.co.uk/wp-content/uploads/2017/03/IMG_20170310_103343-1.jpg"
                });
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 5,
                    Name = "Lab",
                    Description = "Advanced lab equipments.",
                    Capacity = 50,
                    BuildingId = 4,
                    FacilityId = 5,
                    Image = "https://www.ecs.soton.ac.uk/sites/www.ecs.soton.ac.uk/files/University%20of%20Southampton%20STEM_IMG_9039_900x500.jpg"
                });
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel
                {
                    Id = 6,
                    Name = "Study",
                    Description = "Large study rooms.",
                    Capacity = 100,
                    BuildingId = 3,
                    FacilityId = 6,
                    Image = "https://www.bof.co.uk/assets/images/projects/University-of-Southampton-B178-Boldrewood/boldrewood-small-3.png"
                });
        }
    }
}
