using Final_Project.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Controllers;

namespace Final_ProjectTest.Controllers
{
    public class HomeControllerTest
    {

        [Test]
        public void TestIndex()
        {
            HomeController co = new HomeController();
            ViewResult viewResultObj = co.Index() as ViewResult;
            //
            Assert.AreEqual("Index", viewResultObj.ViewName, "hello", true);
        }
    }
}