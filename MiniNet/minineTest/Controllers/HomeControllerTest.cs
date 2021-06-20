using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using mininet.Controllers;
namespace mininetests.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void Test_Index()
        {
            var result = new HomeController().Index();
            Assert.IsTrue(result is ViewResult);
        }
    }
}