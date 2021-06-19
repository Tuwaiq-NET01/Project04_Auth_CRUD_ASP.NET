using HjtProject.Controllers;
using HjtProject.Data;
using HjtProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjtProjectTest.Controllers
{
    class UserProfilesControllerTest
    {
        private UserProfilesController userProfilesController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "ProjectSell").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            userProfilesController = new UserProfilesController(context);
            seed(context);
        }

        [Test]
        public void Check_id_available_Test()
        {
            Assert.IsTrue(userProfilesController.Check_if_in_database("1"));
        }

        [Test]
        public void Check_id_Unvailable_Test()
        {
            Assert.False(userProfilesController.Check_if_in_database("3"));
        }
        public void seed(ApplicationDbContext context)
        {
            var userProfile = new[]
            {
                new UserProfileModel() {Id = "1",email="nice",name="new",pic="",CourseId=1},
                new UserProfileModel() {Id = "2",email="nice2",name="new2",pic="",CourseId=2}
            };
            context.UserProfiles.AddRange(userProfile);
            context.SaveChanges();
        }
    }
}
