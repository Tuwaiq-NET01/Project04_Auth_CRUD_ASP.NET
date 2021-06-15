using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Musicify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // connection with database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // creat table
        public DbSet<SongModel> Songs { get; set; }
        public DbSet<SingerModel> Singers { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<FavoriteModel> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<SongModel>().HasNoKey();*/
            modelBuilder.Entity<SongModel>().HasData(new SongModel { Id = 1, Name = "Sw3at alaseel", Type = "Classic", URL = "https://soundcloud.com/talal_maddah/w2bhodwmmfxr", SingerId=2 });
           // modelBuilder.Entity<SongModel>().HasData(new SongModel { Id = 2, Name = "shift abha", Type = "Classic", URL = "https://soundcloud.com/talal_maddah/zfpybtqymc2d" });

           // modelBuilder.Entity<SingerModel>().HasData(new SingerModel { Id = 1, Name = "Talal", Info = "Talal Maddah, Saudi singer and composer. He has a tremendous impact on Arab culture in the 20th century, and he is the pioneer of modernity in Saudi song, and he is considered the most prominent Saudi artist. He was one of the first who contributed to the spread of the Saudi song outside the Kingdom, as he sang in many cities around the world such as Paris and London.", Photo = "https://pbs.twimg.com/profile_images/1366678263997865987/Hc9pCnMa.jpg" });


        }
    }
}
