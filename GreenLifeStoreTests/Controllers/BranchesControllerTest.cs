using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeStoreTests.Controllers
{
    [TestFixture]
    public class BranchesControllerTest
    {
        [Test]
        public void Branches_Return_Index_View()
        {
            // Arrange
            var controller = new BranchesController(null);
            //Act
            ViewResult viewResultObj = controller.Index2() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);
        }


    }
}
