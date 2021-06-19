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

    class podcast
    {
        private PodcastController _podcast;
        private readonly UserManager<IdentityUser> _userManager;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "podcast").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            _podcast = new PodcastController(context, _userManager);
            seed(context);
        }

        [Test]
        public void Create_Podcast()
        {
            PodcastModel p = new PodcastModel() { Id = 6, Title = "test", Audio = "https://res.cloudinary.com/dhuxwxtfm/video/upload/v1613571243/zwz1nov81nhkbnnj6e6i.mp3", Podcast_image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_4_uhkpiv.jpg", Description = "Lovely life", ProfileId = 1 };
            _podcast.CreatePodcast(p);
            Assert.AreEqual(2, _podcast.Getall().Count);
        }

        [Test]
        public void Edit_Podcast_With_Id()
        {
            PodcastModel p = _podcast.Getall()[0];
            p.Title = "Abdulrahman";


            _podcast.EditPodcast(p);
            Assert.AreEqual("Abdulrahman", _podcast.Getall()[0].Title);
        }

        [Test]
        public void Edit_Game_With_Id_Exception()
        {
            PodcastModel p = new PodcastModel() { Id = 5000, Title = "test", Audio = "https://res.cloudinary.com/dhuxwxtfm/video/upload/v1613571243/zwz1nov81nhkbnnj6e6i.mp3", Podcast_image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_4_uhkpiv.jpg", Description = "Lovely life", ProfileId = 1 };
            Assert.Throws<NullReferenceException>((() => _podcast.EditPodcast(p)));
        }

        public void seed(ApplicationDbContext context)
        {
            var podcast = new[]
            {
              new PodcastModel() {Id = 1, Title = "Don't give up",Audio = "https://res.cloudinary.com/dhuxwxtfm/video/upload/v1613598562/zjxp5qcsetep7pyog0ki.mp3",Podcast_image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg",Description="test",ProfileId=1 }
            };

            context.Podcasts.AddRange(podcast);
            context.SaveChanges();


        }
    }
}
