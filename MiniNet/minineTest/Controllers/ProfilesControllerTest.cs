using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using mininet.Data;
using mininet.Controllers;
using mininet.Models;
namespace mininetests.Controllers
{
    public class ProfilesControllerTest
    {
        private ProfilesController _profile;
        private UserManager<AppUser> _userManager;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MiniTest").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _profile = new ProfilesController(_db, _userManager);
            seeding(_db);
        }
        [Test]
        public void Test_Edit_Valid_Input()
        {
            var result = _profile.EditTest(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }
        [Test]
        public void Test_Edit_Invalid_Input()
        {
            var result = _profile.EditTest(null) as ViewResult;
            System.Console.WriteLine(result.ViewName);
            Assert.AreEqual("_NotFound", result.ViewName);
        }

        public void seeding(ApplicationDbContext _db)
        {
            ProfileModel[] profiles = new[]
            {
                new ProfileModel { Id = 1, Name = "Abdulaziz"}
            };
            _db.profiles.AddRange(
                profiles
            );
            _db.SaveChanges();
        }
    }
}