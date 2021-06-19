using EzzRestaurant.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace EzzRestaurantTest.Controllers
{
    [TestFixture]
    public class CartTest
    {
        public void Index_IsNull()
        {
            //Arrange
            CartController cartController = new CartController();
            //Act
            ViewResult viewResult = cartController.Index() as ViewResult;
            //Assert
            Assert.IsNull(viewResult.ViewName);
        }
    }
}