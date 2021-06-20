using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Musicify.Controllers;
using Musicify.Data;
using Musicify.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMusicify.Controllers
{
    class FavoritesControllerTest
    {
        // if you want to do test unComment from constrakter from the Controler

        private FavoritesController favorites;

        [SetUp]
        public void Setup()
        {
            // for creat database fake 
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Musicfy").Options;
            var context = new ApplicationDbContext(options);
            // for confilict
            context.Database.EnsureDeleted();
            seed(context);
            favorites = new FavoritesController(context);
            
        }
        [Test]
        public void TestIdNegtive()
        {          
            Assert.IsTrue(favorites.Check_Minus(-1));
        }

        [Test]
        public void TestIdPositiv()
        {
            Assert.IsFalse(favorites.Check_Minus(1));
        }
        // for add data in fake datatbase   
        public void seed(ApplicationDbContext context)
        {
            var f = new[]
            {
                new FavoriteModel() {Id = 1,  SongId = 3,  UserId = "abs"},
                new FavoriteModel() {Id = 2,  SongId = 4,  UserId = "def"}
                
            };
            context.Favorites.AddRange(f);
            context.SaveChanges();
        }
    }
}
