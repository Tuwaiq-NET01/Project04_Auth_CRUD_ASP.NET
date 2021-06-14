using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using GreenLifeStore.Models;

namespace GroceryStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BranchModel> Branches { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //insert branches
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 1, Name = "Norah Grocery", Address = "Riyadh" });
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 2, Name = "Norah Grocery", Address = "Dammam" });
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 3, Name = "Norah Grocery", Address = "Jeddah" });

            //insert Users
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            { UserId = 1, FirstName = "Norah", LastName = "Almutairi", Email = "norah@outlook.sa", Password = "Nora12345" , Phone = "0534355512", Address = "Jeddah, Al Marwah, Saeed Albasri street" });
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            { UserId = 2, FirstName = "Maha", LastName = "Alzahrani", Email = "Maha@outlook.sa", Password = "mo6718939", Phone = "0565355519", Address = "Riyadh, Al Narjis, Alsalamah street" });
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            { UserId = 3, FirstName = "Mona", LastName = "Alghamdi", Email = "Mona@outlook.sa", Password = "Moon54321", Phone = "0535366514", Address = "Dammam, Al Rawdah, Malik Ibn Jubair street" });


            //insert Products
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 1, Name = "Apple", ProductDetails="Organic Apple", Price = 1.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/170x165/9df78eab33525d08d6e5fb8d27136e95/1/3/132.jpg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 2, Name = "Orange", ProductDetails = "Orgainc Orange", Price = 1.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/o/r/orange-2.jpg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 3, Name = "Banana", ProductDetails = "Organic Banana", Price = 3.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/5/0/500_0.jpg" });


        }
    }
}

    

