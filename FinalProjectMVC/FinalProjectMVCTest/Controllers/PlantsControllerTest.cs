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
    class PlantsControllerTest
    {
        [Test] // test Edit2 action Plant Controller
        public void Edit2_Return__NotFound_View_When_Id_Is_Null()
        {
            // Arrange
            var controller = new PlantsController(null);
            //Act
            ViewResult viewResultObj = controller.Edit2(id: null) as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("_NotFound", viewResultObj.ViewName);
        }
    }
}
