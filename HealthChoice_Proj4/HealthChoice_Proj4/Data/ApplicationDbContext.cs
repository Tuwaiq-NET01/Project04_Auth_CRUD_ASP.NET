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

            builder.Entity<EventsModel>().HasData(new EventsModel { Id = 1, Name = "Ezz Events", Date = Convert.ToDateTime("2020-6-1"), Overview="Creative apps" , Location="Madinah", Image= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRW3B-BS2WusiV3saTLR6geS3arZRqonNxsBl4PrmunO34ndoXNNq_feMD3_ir62-6My-A&usqp=CAU" });
            builder.Entity<EventsModel>().HasData(new EventsModel { Id = 2, Name = "Samirah Events", Date = Convert.ToDateTime("2020-4-9"), Overview = "Creative apps", Location = "Raif", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9nRLwpIt897OeK8n3DCj7l1VCFEGtf2p8jU2fE0wgYLmfQ60KlY1SVYbMDwq96vv6tM&usqp=CAU" });
            base.OnModelCreating(builder);
        }
    }
}
