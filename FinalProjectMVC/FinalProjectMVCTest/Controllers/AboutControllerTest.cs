using FinalProjectMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using FinalProjectMVC.Data;
using FinalProjectMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinalProjectMVCTest.Controllers
{
    [TestFixture]
    public class AboutControllerTest
    {
        [Test] //test Index action in About Controller 
        public void Index_Return_Corrected_Index_View()
        {
            //Arrange
            AboutController AboutControllerObj = new AboutController();
            //Act
            ViewResult viewResultObj = AboutControllerObj.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);
       }


}
}