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
    class ProfilesControllerTest
    {
        // if you want to do test unComment from constrakter from the Controler

        private ProfilesController Profiles;

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
            Profiles = new ProfilesController(context);

        }
        [Test]
        public void TestGetPL()
        {
            ProfileModel pl = Profiles.getProfile(1);
            Assert.AreEqual(1, pl.Id);
        }

        [Test]
        public void TestGetPlmotFound()
        {
            //PlayListModel pl = PlayLists.getPlayList(3);   // stop program
            Assert.Throws<NullReferenceException>((() => Profiles.getProfile(3)));
        }
        // for add data in fake datatbase   
        public void seed(ApplicationDbContext context)
        {
            var f = new[]
            {
                new ProfileModel() {Id = 1,  Name = "Hassan", Bio="Hi", Photo="",  UserId = "abs"},
                new ProfileModel() {Id = 2,  Name = "Hassan", Bio="Hi", Photo="",  UserId = "abs"}

            };
            context.Profiles.AddRange(f);
            context.SaveChanges();
        }
    }
}
