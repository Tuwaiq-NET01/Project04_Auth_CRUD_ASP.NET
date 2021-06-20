using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPlatform.Controllers;
using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BlogPlatformTests.Controller
{
    public class ProfileControllerTests
    {
        private readonly ProfileController _profileController;

        public ProfileControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "BlogApp").Options;
            var context = new AppDbContext(options);
            context.Database.EnsureDeleted();
            _profileController = new ProfileController(context);
            Seed(context);
        }

        [Fact]
        public async Task Get_Profile_By_Username()
        {
            var profile = await _profileController.GetProfileByUsername("test@test.com");
            var expectedProfile = new Person() {UserName = "test@test.com", Password = "P@ssword123"};
            var json = JsonConvert.SerializeObject(profile.Value);
            Assert.Contains(expectedProfile.UserName, json);
        }

        private void Seed(AppDbContext context)
        {
            var profiles = new[]
            {
                new Person() {UserName = "test@test.com", Password = "P@ssword123"},
            };
            context.Users.AddRange(profiles);
            context.SaveChanges();
        }
    }
}