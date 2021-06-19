using System.Collections.Generic;
using EzzRestaurant.Controllers;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace EzzRestaurantTest.Controllers
{
    [TestFixture]
    public class ProductsTest
    {

        [Test]
        public void Index_IsNull()
        {
            //Arrange
            ProductsController homeController = new ProductsController();
            //Act
            ViewResult viewResult = homeController.Index() as ViewResult;
            //Assert
            Assert.IsNull(viewResult.ViewName);
        }
    }
}
