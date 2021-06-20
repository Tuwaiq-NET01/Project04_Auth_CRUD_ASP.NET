using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace GreenLifeStoreTest
{
    [TestFixture]
    public class HomeControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHomeView()
        {
            //Arrange
            HomeController HomeController = new HomeController(null);

            //Act
            ViewResult viewresult = (ViewResult)HomeController.HomeIndex();

            //Assert
            Assert.AreEqual("Index", viewresult.ViewName);

        }

    }




}
