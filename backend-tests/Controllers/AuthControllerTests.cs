using backend;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace backend_tests.Controllers
{
    [TestClass]
    public class AuthControllerTests
    {
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Test_RegisterUser_Ok_RegularUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/register");
            var rand = new Random();
            int randomNum = rand.Next(1, 100) + rand.Next(1, 100);
            var json = (dynamic)new JsonObject();
            json.username = $"somerandomusername{randomNum}";
            json.email = $"somerandomemail{randomNum}@gmail.com";
            json.password = "Pass1325!";
            json.name = "Random Name";
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_RegisterAdmin_Ok_AdminUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/registeradmin");
            var rand = new Random();
            int randomNum = rand.Next(1, 100) + rand.Next(1, 100);
            var json = (dynamic)new JsonObject();
            json.username = $"somerandomusername{randomNum}";
            json.email = $"somerandomemail{randomNum}@gmail.com";
            json.password = "Pass1325!";
            json.name = "Random Name";
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
