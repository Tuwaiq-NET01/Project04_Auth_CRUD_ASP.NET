using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Project04_Auth_CRUD_ASP.NET.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET_Tests.Controllers
{
    class HomeControllerTest
    {
        [Test]
        public void Index_IndexViewResult()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult viewObj = (ViewResult)controller.Index();

            // Assert
            Assert.AreEqual("Index", viewObj.ViewName);
        }
    }
}
