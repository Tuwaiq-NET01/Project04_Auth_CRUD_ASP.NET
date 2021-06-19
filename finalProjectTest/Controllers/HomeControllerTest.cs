using finalProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProjectTest.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void Return_Correct_Index_View ()
        {
            //Arrange
            HomeController HomeControllerObj = new HomeController(null);
            //Act
            ViewResult viewResultObj = HomeControllerObj.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);
        }
    }
}
