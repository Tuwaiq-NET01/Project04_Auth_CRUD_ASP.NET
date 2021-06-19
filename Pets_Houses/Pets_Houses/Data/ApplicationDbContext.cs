using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pets_Houses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets_Houses.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<Orders_ProductsModel> Orders_Products { get; set; }
        public DbSet<CartModel> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Orders_ProductsModel>()
                .HasOne(o => o.Order)
                .WithMany(p => p.Order_Product)
                .HasForeignKey(f => f.OrderId);

            modelBuilder.Entity<Orders_ProductsModel>()
               .HasOne(o => o.Product)
               .WithMany(p => p.Order_Product)
               .HasForeignKey(f => f.ProductId);



            /*modelBuilder.Entity<ProductModel>().HasData*/

            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 1, ProductName = "Vitakraft Cat Stick Mini Duck and Rabbit", Type = "Food", Image= "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/1a0a7e95-de58-40c8-bb0e-811668f82b92.jpg", Price=10 , Description="" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 2, ProductName = "Burgess Old Cat Food with Turkey & Berries", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/30f89668-6e1e-4691-bf5f-65c51a88fc53.jpg", Price = 40, Description = "Weight: 1.4kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 3, ProductName = "I17 Nutram Ideal Solution Support Indoor Cat Canned Food", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/881b50e2-5d84-46aa-b747-e0a12cb75bd0.png", Price = 10, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 4, ProductName = "S1 Nutram Sound Blaanced Wellness Kitten Canned Food", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/000b5181-c161-4ccb-aa39-b1f8fce5c4d3.png", Price = 7, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 5, ProductName = "Vitakraft Cat Yums Liver Sausage", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/c3c88b68-374a-4324-9902-4b4d079d8c60.jpg", Price = 8, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 6, ProductName = "GimCat Skin & Coat Tabs Beauty Complex", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/3efd1f79-358e-431f-9700-9cd20dec2af2.jpg", Price = 20, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 7, ProductName = "Vitakraft Cat Yums Chicken and Cat Grass", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/39470729-761d-4efe-8eb0-9748d409cec3.png", Price = 8, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 8, ProductName = "GimCat Latte Milk Low in Lactose, 200ml", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/84651856-a067-475c-aa0b-9365840f9877.jpg", Price = 14, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 9, ProductName = "Brit Dog Dry Food Sensitive Lamb", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/c7949b39-af12-4ab4-a877-8872339f4443.jpg", Price = 48, Description = "Weight : 3Kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 10, ProductName = "Brit Dog Dry Food Junior S Chicken", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/ad295124-4190-472c-99d2-b3d4b4a5a7f6.jpg", Price = 120, Description = "Weight : 8Kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 11, ProductName = "Brit Dog Dry Food Adult M Chicken", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/962bf854-0225-4cf4-aca1-63acdb61193e.jpg", Price = 50, Description = "Weight : 3Kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 12, ProductName = "Brit Puppy Dry Food Lamb&Rice ", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/ef59e7b5-0d71-4f00-8a63-50e3d05ece52.jpg", Price = 54, Description = "Weight : 3Kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 13, ProductName = "Brit Dog Dry Food Champion Salmon", Type = "Food", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/d70fc4c6-6a26-403f-8e46-f1f207e5c742.jpg", Price = 30, Description = "Weight : 1Kg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 14, ProductName = "Playing rod with bird With catnip", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/553f21d9-01de-4160-9359-c3fd18a4a20f.png", Price = 17, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 15, ProductName = "Playing tunnel fleece colourful 25×50 cm", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/b1108e16-7231-4f54-9a56-bf38d03ead8e.png", Price = 88, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 16, ProductName = "Owl Toy With Catnip", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/b2dfb935-a807-4437-9b80-87c5c66d7b5d.png", Price = 17, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 17, ProductName = "Playing Rod For Cats", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/bdfeabe4-89ff-4870-8d5e-f1f4c437b7c4.png", Price = 29, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 18, ProductName = "Playing Rope 20 cm", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/f576c5a4-01c6-4ad9-92fd-33d7bdf39739.jpg", Price = 7, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 19, ProductName = "Playing rope with woven in ball", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/fcb3def2-b06e-458d-8a44-f31b2ed5a2d4.png", Price = 17, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 20, ProductName = "Dumbbell For Play 19 cm", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/12bac90a-0e58-4b89-b33a-ae15a564e81f.png", Price = 19, Description = "" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel { Id = 21, ProductName = "BE NORDIC whale Brunold, plush, 25 cm", Type = "Toy", Image = "https://media.zid.store/109d86f9-1e54-40fe-976d-410787c33436/994397bc-6668-4823-adee-ae6ec1f3d43f.jpeg", Price = 30, Description = "" });

            /*modelBuilder.Entity<BranchModel>().Property(branch => branch.Name).IsRequired();

            modelBuilder.Entity<BranchModel>().HasData(new BranchModel { Id = 1, Name = "Br1", Address = "Riyadh", Area = 1 });*/

        }

    }
}
