using Microsoft.AspNetCore.Identity;
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
    class RatingControllerTest
    {
        private RatingController _Rating;
        private readonly UserManager<IdentityUser> _userManager;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Rating").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            _Rating = new RatingController(context, _userManager);
            seed(context);
        }

        [Test]
        public void Create_Rating()
        {
            PodcastProfileModel p = new PodcastProfileModel() { Id = 8, Profile_Id = 2,PodcastId=3 };
            _Rating.CreateRating(p);
            Assert.AreEqual(2, _Rating.GetallRaing().Count);
        }

      

        public void seed(ApplicationDbContext context)
        {
            var Ratng = new[]
            {
              new PodcastProfileModel() {Id=5,Profile_Id=1,PodcastId=1 }
            };

            context.PodcastProfile.AddRange(Ratng);
            context.SaveChanges();


        }
    }
}
