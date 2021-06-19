using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using AppStore.Data;
using AppStore.Models;
using AppStore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace AppStoreTest.Controllers
{
    public class AccountsControllerTest
    {
        /*[SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AppStore").Options;
            
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();

            /*_accountsController = new AccountsController(context , _userManager);
            
            var User = new IdentityUser()
            {
                Id = "f0152a0e-1f56-4532-b305-54163df0648f"
            };
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John Doe"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("name", "John Doe"),
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var ctx = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal()
                    {
                        
                    }
                }
            };#1#

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "Abdullah"),
                new Claim(ClaimTypes.NameIdentifier, "f0152a0e-1f56-4532-b305-54163df0648f"),
            }, "mock"));

            var _accountsController = new AccountsController(context , _userManager);
            
            _accountsController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            
            Console.Error.Write(_accountsController.User);
            var x = _accountsController.User;
        }*/
        
        private AccountsController _accountsController;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AppStore").Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted();
            _accountsController = new AccountsController(_context,_userManager);
        }
        
        [Test]
        public void Account_User_View_Test_Return_ViewResult()
        {
            AccountsController accountsController = new AccountsController(_context,_userManager);

            var result = accountsController.Index("09a7167c22-83f2-4438-aae8-ded96824c67e");
            
            Assert.IsTrue(result is ViewResult);
            Assert.Pass();
        }
        
    }
}