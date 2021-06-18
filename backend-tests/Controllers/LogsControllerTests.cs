using backend;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace backend_tests.Controllers
{
    [TestClass]
    public class LogsControllerTests
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
        public async Task Test_GetLogs_Ok_AsValidUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/logs/{_userId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _regularToken);
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetLogs_Unauthorized_AsInvalidUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/logs/{_userId}");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetLog_NotFound_AsNonUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/logs/NONEXISTENT_USER_ID");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _regularToken);
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
