using FinalProjectMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectMVCTest.Controllers
{

    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void Index_Return_Corrected_Index_View()
        {
            //Arrange
            HomeController AboutControllerObj = new HomeController(null);
            //Act
            ViewResult viewResultObj = AboutControllerObj.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);
        }
     
    }
}
