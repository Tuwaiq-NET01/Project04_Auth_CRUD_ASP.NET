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

    class Files_UploadedControllerTest
    {
        [Test]
        public void Return_Correct_Index_View()
        {
            //Arrange
            Files_UploadedController FilesControllerObj = new Files_UploadedController(null);
            //Act
            ViewResult viewResultObj = FilesControllerObj.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);
        }
    }
}

