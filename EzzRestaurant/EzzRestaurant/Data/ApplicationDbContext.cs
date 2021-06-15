using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EzzRestaurant.Models;

namespace EzzRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderProductsModel> OrderProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding

            // Categories
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 1, Name = "Main Meals",
                Img =
                    "https://images.pexels.com/photos/825661/pexels-photo-825661.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 2, Name = "Juices",
                Img =
                    "https://images.pexels.com/photos/209549/pexels-photo-209549.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 3, Name = "Entrees",
                Img =
                    "https://images.pexels.com/photos/4577740/pexels-photo-4577740.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel()
            {
                Id = 4, Name = "Breakfast",
                Img =
                    "https://images.pexels.com/photos/5591666/pexels-photo-5591666.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });

            // Products
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 1, CategoryId = 1, Name = "Steak", Price = 100.00,
                img =
                    "https://images.pexels.com/photos/3535395/pexels-photo-3535395.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 2, CategoryId = 1, Name = "Pizza", Price = 16.00,
                img =
                    "https://images.pexels.com/photos/825661/pexels-photo-825661.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 3, CategoryId = 1, Name = "spaghetti", Price = 42.00,
                img =
                    "https://images.pexels.com/photos/41320/beef-cheese-cuisine-delicious-41320.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 4, CategoryId = 1, Name = "pasta", Price = 34.00,
                img =
                    "https://images.pexels.com/photos/2703468/pexels-photo-2703468.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 5, CategoryId = 2, Name = "Orange", Price = 14.00,
                img =
                    "https://images.pexels.com/photos/1002778/pexels-photo-1002778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 6, CategoryId = 2, Name = "Mango", Price = 14.00,
                img =
                    "https://images.pexels.com/photos/4023132/pexels-photo-4023132.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 7, CategoryId = 3, Name = "Entrees one", Price = 21.00,
                img =
                    "https://images.pexels.com/photos/4669304/pexels-photo-4669304.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                Id = 8, CategoryId = 4, Name = "Flafel", Price = 21.00,
                img =
                    "https://images.pexels.com/photos/6275118/pexels-photo-6275118.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
            });
            
            // Orders
            modelBuilder.Entity<OrderModel>().HasData(new OrderModel
            {
                Id = 1,
                TotalPrice = 35.0,
                UserId = "c0186483-781b-44b9-b1ce-1f9e55e574bf"
            });
            modelBuilder.Entity<OrderModel>().HasData(new OrderModel
            {
                Id = 2,
                TotalPrice = 156.0,
                UserId = "c0186483-781b-44b9-b1ce-1f9e55e574bf"
            });
            modelBuilder.Entity<OrderModel>().HasData(new OrderModel
            {
                Id = 3,
                TotalPrice = 21.0,
                UserId = "c0186483-781b-44b9-b1ce-1f9e55e574bf"
            });

            // Join Table orders with product
            // here will connect products with orders 
            
            // order #1
            modelBuilder.Entity<OrderProductsModel>().HasData(new OrderProductsModel
            {
                Id = 1,
                OrderId = 1,
                ProductId = 8
            }); 
            modelBuilder.Entity<OrderProductsModel>().HasData(new OrderProductsModel
            {
                Id = 2,
                OrderId = 1,
                ProductId = 5
            });
            
            //order #2
            modelBuilder.Entity<OrderProductsModel>().HasData(new OrderProductsModel
            {
                Id = 3,
                OrderId = 2,
                ProductId = 1
            });
            modelBuilder.Entity<OrderProductsModel>().HasData(new OrderProductsModel
            {
                Id = 4,
                OrderId = 2,
                ProductId = 3
            });
            modelBuilder.Entity<OrderProductsModel>().HasData(new OrderProductsModel
            {
                Id = 5,
                OrderId = 2,
                ProductId = 5
            });
        }
    }
}
