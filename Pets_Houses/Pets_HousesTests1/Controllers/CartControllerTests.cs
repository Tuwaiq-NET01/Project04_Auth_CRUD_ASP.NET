using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pets_Houses.Controllers;
using Pets_Houses.Data;
using Pets_Houses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers.Tests
{ 
    public class CartControllerTests
    {
        private CartController Cartc;
        private ApplicationDbContext db;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "PetsDatabase").Options;
            db = new ApplicationDbContext(options);
            db.Database.EnsureDeleted();// يتأكد انه الداتا بيس محذوفه
            Cartc = new CartController(db);
            seed(db);
            db.SaveChanges();
        }
        [Test]
        public void Delete_Test()
        {
           Cartc.Deletex(1);
            Assert.AreEqual(1, Cartc.count() - 1);

        }
        public void seed(ApplicationDbContext context)
        {
            var cart = new CartModel() {  Id = 1,
         ProductId = 1,
         Image = "",
         ProductName ="",
         Description ="",
         Price = 22,
         Quantity =2 };
            var cart2 = new CartModel()
            {
                Id = 2,
                ProductId = 2,
                Image = "",
                ProductName = "",
                Description = "",
                Price = 22,
                Quantity = 2
            };
            context.Cart.Add(cart);
            context.Cart.Add(cart2);
            context.SaveChanges();
        }
    }
}