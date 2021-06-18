using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Podcast_Website.Controllers;
using Podcast_Website.Data;
using Podcast_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPodcastWebsite.Controllers
{
    class ChannelsControllerTest
    {
        private ChannelsController _Profile;
        

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "profile").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            _Profile = new ChannelsController(context);
            seed(context);
        }
        [Test]
        public void Create_Profile()
        {
            ProfileModel p = new ProfileModel() {Id = 5, Name = "Abdulrahman", Image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg", Background_Image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg", UserId = "A3" };
            _Profile.CreateChannels(p);
            Assert.AreEqual(2, _Profile.GetallProfile().Count);
        }

        public void seed(ApplicationDbContext context)
        {
            var channels = new[]
            {
              new ProfileModel() {Id = 1, Name = "Abdulrahman",Image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg",Background_Image="https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg",UserId="A1" }
            };

            context.Profiles.AddRange(channels);
            context.SaveChanges();


        }
    }
}
