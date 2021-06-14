using Keraa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keraa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductModel>().HasData(new ProductModel() { Id = 2, Catagory = "homie", Name = "drel", ShortDesc = "it is a nice...", CoverImage = "http://....png", IsRented = false });

        }*/


    }
}
