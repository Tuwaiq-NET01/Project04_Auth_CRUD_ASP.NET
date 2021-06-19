using System;
using Final_project.Controllers;
using NUnit.Framework;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Final_projectTest.Contraller
{
    [TestFixture]
    public class AdminContrallerTest
    {
        [Test]
        public void Return_Index_Name_In_Admin()
        {
            AdminController ControllerObj = new AdminController(null);


            ViewResult viewResult = ControllerObj.Index() as ViewResult;

            Assert.AreEqual("Index" ,viewResult.ViewName);

        }
    }
}