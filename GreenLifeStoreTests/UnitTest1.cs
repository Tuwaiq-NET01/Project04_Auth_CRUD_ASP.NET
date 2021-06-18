using GreenLifeStore.Controllers;
using GreenLifeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GreenLifeStoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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

