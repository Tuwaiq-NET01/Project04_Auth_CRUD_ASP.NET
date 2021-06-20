using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MaNodelz.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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


            //Comments
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 1, FoodId = 1, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 2, FoodId = 1, Content = "Dude it's NARUTO'S NODELZZZ OMGGG" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 3, FoodId = 4, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 4, FoodId = 5, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 5, FoodId = 6, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 6, FoodId = 7, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 7, FoodId = 8, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 8, FoodId = 9, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 9, FoodId = 10, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 10, FoodId = 10, Content = "The dish was amazing" });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { Id = 11, FoodId = 12, Content = "The dish was amazing" });
            base.OnModelCreating(modelBuilder);

        }

       public DbSet<FoodModel> Food { get; set; }
       public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       public DbSet<CommentModel> Comments { get; set; }
       public DbSet<FavoriteModel> Favorites { get; set; }
       public DbSet<RateModel> Rate { get; set; }

         
    }
}
