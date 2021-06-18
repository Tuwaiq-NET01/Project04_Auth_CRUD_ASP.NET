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
    class MyprofileControllerTest
    {
        private MyprofileController _myprofile;
        private readonly UserManager<IdentityUser> _userManager;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "myprofile").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            _myprofile = new MyprofileController(context, _userManager);
            seed(context);
        }

        

        [Test]
        public void Edit_Myprofile_With_Id()
        {
            ProfileModel p = _myprofile.GetallProfile()[0];
            p.Name = "Abdulrahman";


            _myprofile.EditProfile(p);
            Assert.AreEqual("Abdulrahman", _myprofile.GetallProfile()[0].Name);
        }

        public void seed(ApplicationDbContext context)
        {
            var myprofile = new[]
            {
              new ProfileModel() {Id = 11, Name = "Ali", Image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg", Background_Image = "https://res.cloudinary.com/duuconncq/image/upload/v1622845572/img_2_o3j8fa.jpg", UserId = "A11" }
            };

            context.Profiles.AddRange(myprofile);
            context.SaveChanges();


        }
    }
}
