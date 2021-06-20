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
    class SingersControllerTest
    {
        // if you want to do test unComment from constrakter from the Controler


        private SingersController Singers;

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
            Singers = new SingersController(context);

        }
        [Test]
        public void TestDelete()
        {
            Singers.DeleteSinger(1);
            
            Assert.AreEqual(1, Singers.getAllSingers().Count);
        }

        [Test]
        public void TestDeleteNotFound()
        {
            //PlayListModel pl = PlayLists.getPlayList(3);   // stop program
            Assert.Throws<NullReferenceException>((() => Singers.DeleteSinger(3)));
        }
        // for add data in fake datatbase   
        public void seed(ApplicationDbContext context)
        {
            var f = new[]
            {
                new SingerModel() {Id = 1,  Name = "Hassan", Photo="",  Info = "abs"},
                new SingerModel() {Id = 2,  Name = "Hussain", Photo="",  Info = "abs"}

            };
            context.Singers.AddRange(f);
            context.SaveChanges();
        }
    }
}
