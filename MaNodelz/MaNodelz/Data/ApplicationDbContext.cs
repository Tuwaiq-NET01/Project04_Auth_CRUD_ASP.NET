using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MaNodelz.Models;
using Microsoft.AspNetCore.Identity;

namespace MaNodelz.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Food
            modelBuilder.Entity<FoodModel>().HasData(new FoodModel { Id = 1, FoodName = "Naruto's Nodelz", FoodDescription = "Hokagy's way of making nodelz", FoodImage = "https://favy-inbound-singapore.s3.amazonaws.com/uploads/topic_item/image/76335/retina_tokyo_style_ramen_with_Naruto.jpg", FoodType="Nodelz",FoodTobePrepared=new TimeSpan(00,20,10) });
            base.OnModelCreating(modelBuilder);

        }

       public DbSet<FoodModel> Food { get; set; }
       public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       public DbSet<CommentModel> Comments { get; set; }
       public DbSet<FavoriteModel> Favorites { get; set; }
       public DbSet<RateModel> Rate { get; set; }

         
    }
}
