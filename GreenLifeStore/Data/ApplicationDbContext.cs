using GreenLifeStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenLifeStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BranchModel> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            //insert branches

            /*
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 1, Name = "Green Life Store", Address = "Riyadh" });
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 2, Name = "Green Life Store", Address = "Dammam" });
            modelBuilder.Entity<BranchModel>().HasData(new BranchModel
            { BranchId = 3, Name = "Green Life Store", Address = "Jeddah" });

            //insert Products
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 1, Name = "Apple", ProductDetails = "Organic Apple", Price = 1.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/170x165/9df78eab33525d08d6e5fb8d27136e95/1/3/132.jpg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 2, Name = "Orange", ProductDetails = "Orgainc Orange", Price = 1.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/o/r/orange-2.jpg" });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            { ProductId = 3, Name = "Banana", ProductDetails = "Organic Banana", Price = 3.5f, Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/5/0/500_0.jpg" });

            */
        }
    }
}

    

 