using System.Collections.Generic;
using EzzRestaurant.Controllers;
using EzzRestaurant.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace EzzRestaurantTest.Controllers
{
    [TestFixture]
   public class CategoriesTest
   {
       [Test]
       public void Index_IsNull()
       {
           //Arrange
           HomeController homeController = new HomeController();
           //Act
           ViewResult viewResult = homeController.Index() as ViewResult;
           //Assert
           Assert.IsNull(viewResult.ViewName);
       }



    }
}
