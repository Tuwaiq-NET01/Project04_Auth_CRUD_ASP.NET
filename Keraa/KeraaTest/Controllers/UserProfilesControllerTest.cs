using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Keraa.Data;
using Keraa.Controllers;
using Keraa.Models;
namespace KeraaTest.Controllers
{
    public class UserProfilesControllerTest
    {
        private UserProfilesController _profile;
        private UserManager<ApplicationUser> _userManager;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestKeraa").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _profile = new UserProfilesController(_db, _userManager);
            seedingDeta(_db);
        }

        public void seedingDeta(ApplicationDbContext _db)
        {
            UserProfileModel[] profiles = new[]
            {
                new UserProfileModel { Id = "1", Name = "Rio", Bio="", Image="", IsOnline=true, UserId="1"}
            };
            _db.UserProfiles.AddRange(
                profiles
            );
            _db.SaveChanges();
        }

        [Test]
        public void Test_Update_With_Valid_Params()
        {
            UserProfileModel u = new UserProfileModel() { Id = "1", Name="Dan" };
            var result = _profile.Update(u).Result as RedirectToActionResult;
            Assert.AreEqual("Index", result);
        }

        public void Test_Update_With_InValid_Data()
        {
            // In this case, it will aslo return to the index(). (:
            UserProfileModel u = new UserProfileModel() { Id = "10000000", Name = "Rio" };
            var result = _profile.Update(u).Result as RedirectToActionResult;
            Assert.AreEqual("Index", result);
        }
        public void Test_Update_With_Unupdatable_Data()
        {
            // In this case, it will aslo return to the index(). (:
            UserProfileModel u = new UserProfileModel() { Id = "4", Name = "Rio" };
            Assert.Throws<NullReferenceException>(()=>_profile.Update(u));
        }



    }
}