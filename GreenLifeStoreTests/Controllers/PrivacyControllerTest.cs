using GreenLifeStore.Controllers;
using GreenLifeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace GreenLifeStoreTests
{
    [TestFixture]
    public class PrivacyControllerTest
    {
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

