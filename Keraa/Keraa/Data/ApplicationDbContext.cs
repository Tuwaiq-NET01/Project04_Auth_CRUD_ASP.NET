using Keraa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keraa.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ChatRoomModel> ChatRooms { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

             modelBuilder.Entity<ProductModel>().HasData(new ProductModel() { Id = 2, Catagory = "homie", Name = "drel", ShortDesc = "it is a nice...", CoverImage = "http://....png", IsRented = false });
         }*/


    }
}
