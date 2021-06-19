using EzzRestaurant.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace EzzRestaurantTest.Controllers
{
    [TestFixture]
    public class HomeTest
    {
        [Test]
        public void Index_AreEqual()
        {
            //Arrange
            HomeController homeController = new HomeController();
            //Act
            ViewResult viewResult = homeController.Index() as ViewResult;
            //Assert
            Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}