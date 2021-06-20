using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace GreenLifeStoreTest
{
    [TestFixture]
    public class PrivacyControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPrivacyView()
        {
            //Arrange

            PrivacyController privacyController = new PrivacyController();

            //Act

            ViewResult viewresult = (ViewResult)privacyController.Index();

            //Assert
            Assert.AreEqual("Index", viewresult.ViewName);
      
    }
}
    }

