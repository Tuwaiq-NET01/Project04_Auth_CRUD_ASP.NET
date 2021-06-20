using System;
using Final_project.Controllers;
using NUnit.Framework;

using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Final_projectTest.Contraller
{
   [TestFixture]
        public class HomeControllerTest
        {
            [Test]
            public void Return_Index_Name_In_Home()
            {
            HomeController ControllerObj = new HomeController(null);


                ViewResult viewResult = ControllerObj.Index() as ViewResult;

                Assert.AreEqual("Index", viewResult.ViewName);
            
            }
        }
}
