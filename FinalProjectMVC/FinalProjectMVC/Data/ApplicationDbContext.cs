using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Add Table Customer
        public DbSet<PlantModel> Plants { get; set; }
        //Add Table Customer
        public DbSet<PlantStore> PlantStores { get; set; }
        //Add Table Customer
        public DbSet<PlantCareModel> PlantCares { get; set; }
        
        //Add Table Customer relation one to many
        public DbSet<ContactModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding  Plant
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 1, PlantName = "Rosemary", PlantType = "indoor plants", PlantColor = "green", Price = 200, PlantHeight = 40, Image = "https://www.nabataty.com/store/wp-content/uploads/2021/04/2837.jpg" ,StoreId = 100 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 2, PlantName = "Clathia Flame", PlantType = "indoor plants", PlantColor = "green with purple", Price = 300, PlantHeight = 60, Image = "https://www.nabataty.com/store/wp-content/uploads/2021/05/2944.jpg" ,StoreId = 100 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 3, PlantName = "Roses", PlantType = "indoor plants", PlantColor = "yellow", Price = 40, PlantHeight = 30, Image = "https://cdn.salla.sa/AApPZ/IfXTx6DhLUQHg6T4bF2C1xyegeJCKH5eQTMkG2Rl.jpg" });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 4, PlantName = "Kaluna", PlantType = "outdoor plants", PlantColor = "pink", Price = 100, PlantHeight = 60, Image = "https://www.nabataty.com/store/wp-content/uploads/2020/10/1519.jpg" });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 5, PlantName = "Bird of Paradise", PlantType = "outdoor plants", PlantColor = "green with yellow", Price = 200, PlantHeight = 50, Image = "https://d1aqy00qjeidmk.cloudfront.net/upload/product/product1-1605788685.jpg", StoreId = 100 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 6, PlantName = "Chilevera", PlantType = "indoor plants", PlantColor = "green", Price = 150, PlantHeight = 70, Image = "https://static.wixstatic.com/media/a27d24_1415dbffce734563a41e5859a507dc82~mv2.jpg/v1/fill/w_1000,h_1274,al_c,q_90,usm_0.66_1.00_0.01/a27d24_1415dbffce734563a41e5859a507dc82~mv2.jpg", StoreId = 200 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 7, PlantName = "Olive Tree", PlantType = "outdoor plants", PlantColor = "green", Price = 80, PlantHeight = 120, Image = "https://www.nabataty.com/store/wp-content/uploads/2020/06/982.jpg" });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 8, PlantName = "Basil", PlantType = "in/out/door plants", PlantColor = "green with purple", Price = 40, PlantHeight = 30, Image = "https://media.zid.store/thumbs/c9146352-5f34-4d3a-8115-22631018afb2/e19a1dca-ecd5-497b-8c1d-7bf6321a1d8a-thumbnail-370x370.png", StoreId = 200 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 9, PlantName = "Fix", PlantType = "in/out/door plants", PlantColor = "green", Price = 100, PlantHeight = 20, Image = "https://qtrees.com/wp-content/uploads/2020/10/unnamed.jpg", StoreId = 100 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 10, PlantName = "Newreglia", PlantType = "indoor plants", PlantColor = "green with red", Price = 300, PlantHeight = 40, Image = "https://www.nabataty.com/store/wp-content/uploads/2021/01/1910-A.jpg", StoreId = 200 });
            modelBuilder.Entity<PlantModel>().HasData(new PlantModel { PlantId = 11, PlantName = "Basil", PlantType = "in/out/door plants", PlantColor = "green with purple", Price = 40, PlantHeight = 30, Image = "https://media.zid.store/thumbs/c9146352-5f34-4d3a-8115-22631018afb2/e19a1dca-ecd5-497b-8c1d-7bf6321a1d8a-thumbnail-370x370.png", StoreId = 200 });

            // Seeding  store plant
            modelBuilder.Entity<PlantStore>().HasData(new PlantStore { StoreId = 100, StoreName = "Plant Store", StoreLocation = "Riyadh", StorePhoneNo = "011188374", StoreEmail = "PR@mail.com" });
            modelBuilder.Entity<PlantStore>().HasData(new PlantStore { StoreId = 200, StoreName = "Plant Store", StoreLocation = "Jeddah", StorePhoneNo = "014883", StoreEmail = "PJ@mail.com" });

            // Seeding   plant care
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 110, light = "Yes", temperature = 20.0, irrigation = "Twice", plantId = 1});
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 210, light = "Yes", temperature = 25, irrigation = "Once", plantId = 2 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 310, light = "No", temperature = 28.0, irrigation = "Twice", plantId = 3 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 410, light = "No", temperature = 25, irrigation = "Once", plantId = 4 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 510, light = "Yes", temperature = 20.0, irrigation = "Twice", plantId= 5 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 610, light = "Yes", temperature = 25, irrigation = "Once", plantId = 6 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 710, light = "No", temperature = 29.0, irrigation = "Twice", plantId = 7 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 810, light = "No", temperature = 25, irrigation = "Once", plantId = 8 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 910, light = "Yes", temperature = 30.0, irrigation = "Twice", plantId = 9 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 1110, light = "No", temperature = 25, irrigation = "Once", plantId = 10 });
            modelBuilder.Entity<PlantCareModel>().HasData(new PlantCareModel { PlantCareId = 2110, light = "Yes", temperature = 20.0, irrigation = "Twice", plantId = 11 });



        }
    }
}
