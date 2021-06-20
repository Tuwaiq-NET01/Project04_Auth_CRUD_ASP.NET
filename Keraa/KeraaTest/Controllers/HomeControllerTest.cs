using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Keraa.Controllers;
using Microsoft.Extensions.Logging;

namespace KeraaTest.Controllers
{
    class HomeControllerTest
    {
        private readonly ILogger<HomeController> _logger;

        [Test]
        public void Test_Index()
        {
        var result = new HomeController(_logger).Index();
            Assert.IsTrue(result is ViewResult);
        }
    }
}
