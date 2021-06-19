using System;
using System.Collections.Generic;
using System.Text;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppModel> Apps { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<DownloadModel> Downloads { get; set; }

        public DbSet<RatingModel> Ratings { get; set; }

        public DbSet<AppCategoryModel> AppsCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed App
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 1, Name = "Whatsapp", Description = "Massenger App", GeneralCategory = "Social Media",
                DownloadsCount = 0, Icon = "https://upload.wikimedia.org/wikipedia/commons/6/6b/WhatsApp.svg",
                Size = "100MB",
                AverageRating = 0
            });
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 2, Name = "Twitter", Description = "Tweets App", GeneralCategory = "Social Media",
                DownloadsCount = 0,
                Icon =
                    "https://png.pngtree.com/png-clipart/20190613/original/pngtree-twitter-icon-png-image_3584901.jpg",
                Size = "40MB",
                AverageRating = 0
            });
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 3, Name = "FaceBook", Description = "Social Media App", GeneralCategory = "Social Media",
                DownloadsCount = 0,
                Icon = "https://facebookbrand.com/wp-content/uploads/2019/04/f_logo_RGB-Hex-Blue_512.png?w=512&h=512",
                Size = "150MB",
                AverageRating = 0
            });
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 4, Name = "Wild Rift", Description = "League Of Legends On Mobile", GeneralCategory = "Games",
                DownloadsCount = 0,
                Icon =
                    "https://static.wikia.nocookie.net/leagueoflegends/images/b/be/Wild_Rift_icon.png/revision/latest?cb=20191018194406",
                Size = "3GB",
                AverageRating = 0
            });
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 5, Name = "Chess", Description = "Chess Game", GeneralCategory = "Games",
                DownloadsCount = 0,
                Icon = "https://media.istockphoto.com/vectors/chess-icon-on-white-background-vector-id931757036",
                Size = "20MB",
                AverageRating = 0
            });
            modelBuilder.Entity<AppModel>().HasData(new AppModel()
            {
                Id = 6, Name = "Minecraft", Description = "Building, Survival Game", GeneralCategory = "Games",
                DownloadsCount = 0,
                Icon =
                    "https://external-preview.redd.it/INBHMCNdcPNCBvgGn3yQ-RH4jiAhFP4bde7-wCC2xiw.png?auto=webp&s=7fbcf884991ea6c916da84752af364fbf962687b",
                Size = "250MB",
                AverageRating = 0
            });


            // Seed Category
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 1, Name = "Chatting"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 2, Name = "News"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 3, Name = "Social Networking"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 4, Name = "Adventure"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 5, Name = "Action"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 6, Name = "Strategy"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 7, Name = "Puzzle"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 8, Name = "Building"
            });
            
            // Seed AppsCategories


            // Twitter
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 1,AppId = 1 , CategoryId = 1
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 2,AppId = 1 , CategoryId = 3
            });
            // Whatsapp
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 3,AppId = 2 , CategoryId = 2
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 4,AppId = 2 , CategoryId = 3
            });
            // Facebook
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 5,AppId = 3 , CategoryId = 1
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 6,AppId = 3 , CategoryId = 2
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 7,AppId = 3 , CategoryId = 3
            });
            
            // Wild 
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 8,AppId = 4 , CategoryId = 4
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 9,AppId = 4 , CategoryId = 5
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 10,AppId = 4 , CategoryId = 6
            });
            // Chess
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 11,AppId = 5 , CategoryId = 6
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 12,AppId = 5 , CategoryId = 7
            });
            //mine
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 13,AppId = 6 , CategoryId = 4
            });
            modelBuilder.Entity<AppCategoryModel>().HasData(new AppCategoryModel()
            {
                Id = 14,AppId = 6 , CategoryId = 8
            });            
            
        }
    }
}