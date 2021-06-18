using backend;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace backend_tests.Controllers
{
    [TestClass]
    public class ChunkControllerTests
    {
        private static WebApplicationFactory<Startup> _factory;
        private readonly string _regularToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlciIsImp0aSI6IjQwMWNmNzYyLTE5ZjMtNDNlZS1hZWFhLWUyNDZkZGQ4YWM0OSIsImV4cCI6MTYyNDEwMzAzOSwiaXNzIjoiSXNzdWVyIiwiYXVkIjoiQXVkaWVuY2UifQ.Eqlj4WBV9gjSBYhO64ujEnLYF_dLh824854IfGDv1kY";
        private readonly string _userId = "4f61a354-0cd6-4b4f-a2c7-a6ab90a59b5b";

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Test_PostFileToShred_NotFound_AsNonexistentFile()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/chunk/{FileName}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _regularToken);
            var rand = new Random();
            int randomNum = rand.Next(1, 100) + rand.Next(1, 100);
            var json = (dynamic)new JsonObject();
            json.chunksPassword = $"{randomNum}";
            json.refPassword = $"{randomNum}";
            json.userId = _userId;
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
