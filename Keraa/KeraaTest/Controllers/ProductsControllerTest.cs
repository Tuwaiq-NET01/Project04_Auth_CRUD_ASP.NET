using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Keraa.Data;
using Keraa.Controllers;
using Keraa.Models;
using Microsoft.Extensions.Configuration;

namespace mininetests.Controllers
{
    public class ProductsControllerTest
    {
        private ProductsController _products;
        private UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration Configuration;
       

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestKeraa").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _products = new ProductsController(_db, _userManager, Configuration);
            seedingDeta(_db);
        }

        public void seedingDeta(ApplicationDbContext _db)
        {
            ProductModel[] products = new[]
            {
                new ProductModel { Id = 1, Catagory = "outdoor", Name="Cable", ShortDesc="used cable, in goof condition ", CoverImage="www.R.png", IsRented=false}
            };
            _db.Products.AddRange(
                products
            );
            _db.SaveChanges();
        }

        [Test]
        public void Test_Details_Invalid_Id()
        {
            var result = _products.Details(2) as ViewResult;
            Assert.AreEqual("_NotFound", result);
        }

        public void Test_Details_Empty_Id()
        {
            var result = _products.Details(null) as ViewResult;
            Assert.AreEqual("_NotFound", result);
        }

        public void Test_Details_valid_Id()
        {
            var result = _products.Details(1) as ViewResult;
            Assert.AreEqual("Product", result);
        }
    }
}

        