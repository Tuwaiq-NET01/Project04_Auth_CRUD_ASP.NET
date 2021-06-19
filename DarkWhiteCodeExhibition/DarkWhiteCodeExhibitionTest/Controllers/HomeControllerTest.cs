using Microsoft.VisualStudio.TestTools.UnitTesting;
using DarkWhiteCodeExhibitionTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using DarkWhiteCodeExhibition.Controllers;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarkWhiteCodeExhibition.Controllers.Tests
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void IndexTest()
        {
            //Arrange
            HomeController ControllerObj = new HomeController(null);
            //Act
            ViewResult viewObj = ControllerObj.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewObj.ViewName);
        }

    }
}