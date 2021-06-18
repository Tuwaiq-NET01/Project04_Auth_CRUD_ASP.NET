using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Podcast_Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPodcastWebsite.Controllers
{
    class HomeControllerTest
    {
        private readonly ILogger<HomeController> _logger;

        


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Index_ReturnHomeIndexView()
        {
            HomeController Home = new HomeController(_logger);
            ViewResult viewObj = (ViewResult)Home.Index();
            Assert.AreEqual("Index", viewObj.ViewName);
        }
    }
}
