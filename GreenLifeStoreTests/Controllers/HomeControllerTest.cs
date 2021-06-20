using GreenLifeStore.Controllers;
using GreenLifeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace GreenLifeStoreTests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void TestHomeView()
        {
            //Arrange
            HomeController HomeController = new HomeController(null);

            //Act
            ViewResult viewresult = (ViewResult)HomeController.Index();

            //Assert
            Assert.AreEqual("Index", viewresult.ViewName);

        }

    }




}
