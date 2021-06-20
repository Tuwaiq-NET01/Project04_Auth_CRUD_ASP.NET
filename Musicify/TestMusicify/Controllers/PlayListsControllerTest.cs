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
    class PlayListsControllerTest
    {
        // if you want to do test unComment from constrakter from the Controler

        private PlayListsController PlayLists;

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
            PlayLists = new PlayListsController(context);

        }
        [Test]
        public void TestGetPL()
        {
            PlayListModel pl = PlayLists.getPlayList(1);
            Assert.AreEqual(1, pl.Id);
        }

        [Test]
        public void TestGetPlmotFound()
        {
            //PlayListModel pl = PlayLists.getPlayList(3);   // stop program
            Assert.Throws<NullReferenceException>((() => PlayLists.getPlayList(3)));
        }
        // for add data in fake datatbase   
        public void seed(ApplicationDbContext context)
        {
            var f = new[]
            {
                new PlayListModel() {Id = 1,  Name = "Hassan",  UserId = "abs"},
                new PlayListModel() {Id = 2,  Name = "Abdulmajed",  UserId = "def"}

            };
            context.PlayLists.AddRange(f);
            context.SaveChanges();
        }

    }

}
