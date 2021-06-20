using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TuwaiqCVMaker.Controllers;

namespace TuwaiqCVMakerTests
{
    public class OidcControllerTests
    {
        [Test]
        public void GetClientRequestParameters()
        {
            // Arrange
            var expectedStatusCode = 200;
            var logger = Mock.Of<ILogger<OidcConfigurationController>>();
            var clientReqParamProvider = Mock.Of<IClientRequestParametersProvider>();
            var controller = new OidcConfigurationController(clientReqParamProvider, logger);
            
            
            // Act
            var actionResult = controller.GetClientRequestParameters("TuwaiqCVMaker");
            
            // Assert
            Assert.IsTrue(actionResult is OkObjectResult, "Invalid action result type");
            var result = actionResult as OkObjectResult;
            
            Assert.AreEqual(expectedStatusCode, result.StatusCode, "Invalid status code");
            Assert.Pass();
        }
    }
}