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
    class SongsControllerTest
    {
        // if you want to do test unComment from constrakter from the Controler

        private SongsController Songs;

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
            Songs = new SongsController(context);

        }
        [Test]
        public void TestDelete()
        {
            Songs.DeleteSong(1);

            Assert.AreEqual(1, Songs.getAllSongs().Count);
        }

        [Test]
        public void TestDeleteNotFound()
        {
            //PlayListModel pl = PlayLists.getPlayList(3);   // stop program
            Assert.Throws<NullReferenceException>((() => Songs.DeleteSong(5)));
        }
        // for add data in fake datatbase   
        public void seed(ApplicationDbContext context)
        {
            var data = new[]
            {
                new SongModel() {Id = 1,  Name = "Hassan",  Type = "ii" , URL="" , SingerId=2},
                new SongModel() {Id = 2,  Name = "Da7m",  Type = "ii" , URL="" , SingerId=1}

            };
            context.Songs.AddRange(data);
            context.SaveChanges();
        }
    }
}
