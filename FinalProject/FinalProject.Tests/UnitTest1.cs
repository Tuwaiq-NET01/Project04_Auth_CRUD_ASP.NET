using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FinalProject.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task GetCelebrities()
        {

            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Celebrities");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public async Task GetFanTests()
        {

            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Fan");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public async Task GetFanReqeustCelebrityTests()
        {

            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/FanReqeustCelebrity");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public async Task GetCelebrityVideoTests()
        {

            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/CelebrityVideo");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
