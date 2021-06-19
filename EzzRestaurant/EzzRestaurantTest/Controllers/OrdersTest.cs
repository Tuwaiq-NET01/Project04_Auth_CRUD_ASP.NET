using System;
using EzzRestaurant.Controllers;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace EzzRestaurantTest.Controllers
{
    [TestFixture]
    public class OrdersTest
    {
        [Test]
        public void Index_Exception()
        {
            //Arrange
            OrdersController orderModel = new OrdersController();
           
            //Assert
            Assert.Throws<NullReferenceException>( () => orderModel.Index(""));
        }
    }
}