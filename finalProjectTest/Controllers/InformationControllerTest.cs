using finalProject.Controllers;
using finalProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProjectTest.Controllers
{
    [TestFixture]
    class InformationControllerTest
    {
        [Test]
        public void EditTest_Return_Index_View_When_Id_Is__Null()
        { 
            // Arrange
            var controller = new InformationController(null);
            //Act
            ViewResult viewResultObj = controller.EditTest(id: null) as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("_NotFound" , viewResultObj.ViewName);
        }
    }
}
