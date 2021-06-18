using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Podcast_Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPodcastWebsite.Controllers
{
    class RandomPodcastControllerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Index_ReturnRandomeIndexView()
        {
            RandomPodcastController RandomPodcast = new RandomPodcastController();
            ViewResult viewObj = (ViewResult)RandomPodcast.Index();
            Assert.AreEqual("Index", viewObj.ViewName);
        }
    }
}
