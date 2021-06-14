using Adoption.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adoption.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding (run this only once put it as comment after you update database with it)
            modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 1, name = "Vetsreet", phone = "303849244", address = "505 broadway st" });
            modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 2, name = "Pawpatrol", phone = "758348939", address = "404 broadway st" });
            modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 3, name = "smartPet", phone = " 7548484844 ", address = "303 broadway st" });
            
            //seeding (run this only once put it as comment after you update database with it)
            modelBuilder.Entity<CatModel>().HasData(new CatModel { id = 1, OwnerId = 1, AdopterId = 1, name = "Kat", age = "young", description = "Hi! My name is Kat and I’m an extremely friendly curious and social 1 year old. ( Shy at first of course...;)...)....I’m told I have exotic unique markings with silky coat you can’t even dream of ...;) My ideal home has very affectionate humans who don’t mind my daily exploring. I’m super flirty and love cuddling in with my foster mom in her bed and my siblings as well. If you’re looking for a catTable with a dog personality then I will be your gal. ♥️", gender = "female", breed = "Domestic Shorthair", image = "https://pet-uploads.adoptapet.com/6/2/9/547432893.jpg", health = "Spayed / neutered.", LocationId = 1 });
            modelBuilder.Entity<CatModel>().HasData(new CatModel { id = 2, OwnerId = 1, AdopterId = 1, name = "Antoine and Beauregaurd", age = "young", description = " They are named Beauregaurd and Antoine. They are the smartest cats I have ever interacted with and and know words and love one another deeply. They are loving yet independent and will play for hours on end with either myself or another. I have an enclosed outdoor space they love to hang out in.", gender = "male", breed = " Bengal", image = "https://pet-uploads.adoptapet.com/8/b/9/546264169.jpg", health = "Spayed / neutered.", LocationId = 2 });
            modelBuilder.Entity<CatModel>().HasData(new CatModel { id = 3, OwnerId = 1, AdopterId = 1, name = "Elizabeth Taylor", age = "young", description = "Meet the ever-glamorous Elizabeth Taylor.she's 10 months old, like most celebrities, she’s reclusive and prefers a quiet environment. Elizabeth is also very shy and will require someone with patience. However, she is not shy when it’s time for catTable treats! Elizabeth is a strict pescatarian, enjoying the finest fish and seafood. She also enjoys living her best life playing with her favorite toy balls. This exquisite girl has the most beautiful markings with a black whip-like tail and bangs. She is a glamorous girl and is looking for her up upscale forever home.", gender = "female", breed = "Domestic Shorthair", image = "https://pet-uploads.adoptapet.com/8/8/f/442558865.jpg", health = "Spayed / neutered.", LocationId = 3 });

            //seeding (run this only once put it as comment after you update database with it)
            modelBuilder.Entity<OwnerModel>().HasData(new OwnerModel { id = 1, name = "Rose", phone = " 85454995042 ", age = 24, gender = "female", email = "roro@gmail.com", reason = "relocating", image = "https://images.unsplash.com/photo-1508002366005-75a695ee2d17?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80" });
            modelBuilder.Entity<OwnerModel>().HasData(new OwnerModel { id = 2, name = "Jack", phone = " 46736437743 ", age = 54, gender = "male", email = "jojo@gmail.com", reason = "relocating", image = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80" });

            //seeding (run this only once put it as comment after you update database with it)
            modelBuilder.Entity<AdopterModel>().HasData(new AdopterModel { id = 1, name = "Ken", phone = " 85454995042 ", age = 42, gender = "male", email = "koko@gmail.com", image = "https://images.unsplash.com/photo-1521119989659-a83eee488004?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=728&q=80" });
            modelBuilder.Entity<AdopterModel>().HasData(new AdopterModel { id = 2, name = "Natasha", phone = " 46736437743 ", age = 30, gender = "female", email = "momo@gmail.com", image = "https://images.unsplash.com/photo-1514448553123-ddc6ee76fd52?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=668&q=80" });


            base.OnModelCreating(modelBuilder);
        }

        // create sql table 
        public DbSet<CatModel> catTable { get; set; }
        public DbSet<AdopterModel> adopter { get; set; }
        public DbSet<OwnerModel> owner { get; set; }
        public DbSet<LocationModel> location { get; set; }
    
    }
}
