using GiftShopV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopV1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<FlowerModel> Flowers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerModel>().HasData(new CustomerModel { CustomerId = 1, FirstName = "Alexia", LastName = "Perry", Username = "AlexPer", Password = "123", Email = "Alexia@hotmail.com", PhoneNumber = "055-569-9110", Location = "NY" });
            modelBuilder.Entity<CustomerModel>().HasData(new CustomerModel { CustomerId = 2, FirstName = "Rita", LastName = "Farr", Username = "RitaF", Password = "234", Email = "RitaF@hotmail.com", PhoneNumber = "050-569-9110", Location = "LA" });
            modelBuilder.Entity<CustomerModel>().HasData(new CustomerModel { CustomerId = 3, FirstName = "Tony", LastName = "Roberts", Username = "TonyRob", Password = "345", Email = "TonyR@hotmail.com", PhoneNumber = "054-932-6548", Location = "FL" });
            modelBuilder.Entity<CustomerModel>().HasData(new CustomerModel { CustomerId = 4, FirstName = "Amelia", LastName = "Owen", Username = "AmeliaOwen", Password = "456", Email = "AmeliaO@hotmail.com", PhoneNumber = "051-436-5094", Location = "CA" });
            modelBuilder.Entity<CustomerModel>().HasData(new CustomerModel { CustomerId = 5, FirstName = "Kyle", LastName = "Fox", Username = "KyFox", Password = "567", Email = "KyleF@hotmail.com", PhoneNumber = "059-330-4393", Location = "NY" });

            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 10, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637447438702232017.jpg?w=500", FlowerName = "Pink Dust", FlowerPrice = 310.50m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 11, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637375823162633954.jpg?w=500", FlowerName = "Breeze", FlowerPrice = 322.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 12, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637467433600235841.jpg?w=500", FlowerName = "Love Mix", FlowerPrice = 360.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 13, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637368837979802520.jpg?width=600", FlowerName = "Sleek Bouquet", FlowerPrice = 200.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 14, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363759603959215.jpg?width=600", FlowerName = "35 Roses hand bouquet III", FlowerPrice = 280.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 15, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363761825283068.jpg?width=600", FlowerName = "50 Roses hand bouquet II", FlowerPrice = 414.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 16, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637448274952847223.jpg?width=600", FlowerName = "White and Yellow Roses", FlowerPrice = 230.50m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 17, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637503588358822359.jpg?width=600", FlowerName = "Pink Roses", FlowerPrice = 312.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 18, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637502715042825399.jpg?width=600", FlowerName = "Purple Tulips", FlowerPrice = 430.00m });

        }
    }
}
