using System.Threading.Tasks;
using BlogPlatform.Controllers;
using BlogPlatform.Data;
using BlogPlatform.Models;
using BlogPlatform.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace BlogPlatformTests.Controller
{
    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly UserManager<Person> _userManager;
        private readonly IAuthManager _authManager;

        public AccountControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "BlogApp").Options;
            var context = new AppDbContext(options);
            context.Database.EnsureDeleted();
            _accountController = new AccountController(_userManager, _authManager);
        }

        [Fact]
        public async Task Register_User()
        {
            var profile =  _accountController.Register(new Person()
                {UserName = "test@test.com", Password = "P@ssword123"});
            var result = profile.Result as AcceptedResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Return_Unauthorized_On_Invalid_Login()
        {
            var profile = _accountController.Login(new Person()
                {UserName = "user@email.com", Password = "P@ssword123"});
            var result = profile.Result as UnauthorizedResult;
            Assert.Equal(401, result.StatusCode);
        }

    }
}