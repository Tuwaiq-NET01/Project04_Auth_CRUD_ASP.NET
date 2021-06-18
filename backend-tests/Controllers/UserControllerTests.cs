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
    public class UserControllerTests
    {
        private static WebApplicationFactory<Startup> _factory;
        private readonly string _adminToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJqdGkiOiJhMTVlZGMxNi1mZDU0LTQyYjMtODgwNS01NWZlZDI4ZTEwYjAiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTYyNDEwMjg0OSwiaXNzIjoiSXNzdWVyIiwiYXVkIjoiQXVkaWVuY2UifQ.-9k9uV8zuzERHsMjJo3sAuf_L7qlh31DOm_ypQMfZh4";
        private readonly string _regularToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlciIsImp0aSI6IjQwMWNmNzYyLTE5ZjMtNDNlZS1hZWFhLWUyNDZkZGQ4YWM0OSIsImV4cCI6MTYyNDEwMzAzOSwiaXNzIjoiSXNzdWVyIiwiYXVkIjoiQXVkaWVuY2UifQ.Eqlj4WBV9gjSBYhO64ujEnLYF_dLh824854IfGDv1kY";
        private readonly string _userId = "4f61a354-0cd6-4b4f-a2c7-a6ab90a59b5b";

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Test_GetUser_Ok_AsAdminUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/user");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _adminToken);
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetUser_Forbidden_AsRegularUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/user");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _regularToken);
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetUser_Unauthorized_AsNoToken()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/user/");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_DeleteUser_NotFound_AsNoUser()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/user/NONEXISTENT_USER_ID");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _regularToken);
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task Test_DeleteUser_Unauthorized_AsNoToken()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/user/{_userId}");
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
