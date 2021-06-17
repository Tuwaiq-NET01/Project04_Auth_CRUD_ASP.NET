using Coffee.Controllers;
using Coffee.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTest.Controllers
{
    [TestFixture]
    class BeansControllerTest
    {
        [Test]
        public void Index2_Beans_AreEqual()
        {
            //Arrange
            BeansController beansController = new BeansController();

            //Act
            ViewResult viewResult = beansController.Index2() as ViewResult;

            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResult.ViewName);

        }


    }
}
