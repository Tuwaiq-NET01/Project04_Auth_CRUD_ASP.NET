using HealthChoice_Final_crud_auth.Controllers;
using HealthChoice_Proj4.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4Test.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void Index2_AreEqual()
        {
            //Arrange
            HomeController HomeController = new HomeController();
            //Act
            ViewResult viewResult = HomeController.Index() as ViewResult;
            //Assert
           Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
