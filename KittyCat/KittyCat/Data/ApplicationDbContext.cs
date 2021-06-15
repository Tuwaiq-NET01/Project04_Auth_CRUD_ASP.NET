using KittyCat.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KittyCat.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*            dynamic Animals = JObject.Parse(FetchAPI.httpReq());
                        foreach (var animal in Animals.animals)
                        {
                            Console.WriteLine(animal.Id);
                            // modelBuilder.Entity<CatModel>().HasData(new CatModel { });
                        }*/



            //seeding (run this only once put it as comment after you update database with it)
            /*  modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 1, name = "Vetsreet", phone = "303849244", address = "505 broadway st" });
              modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 2, name = "Pawpatrol", phone = "758348939", address = "404 broadway st" });
              modelBuilder.Entity<LocationModel>().HasData(new LocationModel { id = 3, name = "smartPet", phone = " 7548484844 ", address = "303 broadway st" });


              //seeding (run this only once put it as comment after you update database with it)
              modelBuilder.Entity<OwnerModel>().HasData(new OwnerModel { id = 1, name = "Rose", phone = " 85454995042 ", age = 24, gender = "female", email = "roro@gmail.com", reason = "relocating", image = "https://images.unsplash.com/photo-1508002366005-75a695ee2d17?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80" });
              modelBuilder.Entity<OwnerModel>().HasData(new OwnerModel { id = 2, name = "Jack", phone = " 46736437743 ", age = 54, gender = "male", email = "jojo@gmail.com", reason = "relocating", image = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80" });

              //seeding (run this only once put it as comment after you update database with it)
              modelBuilder.Entity<AdopterModel>().HasData(new AdopterModel { id = 1, name = "Ken", phone = " 85454995042 ", age = 42, gender = "male", email = "koko@gmail.com", image = "https://images.unsplash.com/photo-1521119989659-a83eee488004?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=728&q=80" });
              modelBuilder.Entity<AdopterModel>().HasData(new AdopterModel { id = 2, name = "Natasha", phone = " 46736437743 ", age = 30, gender = "female", email = "momo@gmail.com", image = "https://images.unsplash.com/photo-1514448553123-ddc6ee76fd52?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=668&q=80" });

              getImages(modelBuilder);*/

            base.OnModelCreating(modelBuilder);
        }

        // create sql table 
        public DbSet<CatModel> catTable { get; set; }
        public DbSet<AdopterModel> adopter { get; set; }
        public DbSet<OwnerModel> owner { get; set; }
        public DbSet<LocationModel> location { get; set; }
    }
}
