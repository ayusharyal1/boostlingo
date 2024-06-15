using BoostlingoApp.Application.Queries;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoostlingoApp.UnitTests
{
    [TestClass]
    public class GetJsonDataQueryHandlerTests
    {
        [TestMethod]
        public async Task Validate_DoesNotThrowException_WhenAbleToFetchData()
        {
            var jsonGatewayMock = new Mock<IJsonDataHttpGateway>();
            IEnumerable<User> users = new List<User>() { new User() { Id = "1111"} };
            
            var loggerMock = new Mock<ILogger<GetJsonDataQueryHandler>>();
            jsonGatewayMock.Setup(
                    x => x.GetJsonDataQueryAsync()
                    ).Returns(Task.FromResult(users));
            var sut = new GetJsonDataQueryHandler(jsonGatewayMock.Object,loggerMock.Object);
            var result = await sut.Execute();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1 );
            Assert.AreEqual(users.First().Id, result.First().Id);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public async Task Validate_DoesNotThrowException_WhenUnableToFetchData() 
        {
            var jsonGatewayMock = new Mock<IJsonDataHttpGateway>();
            var loggerMock = new Mock<ILogger<GetJsonDataQueryHandler>>();
            jsonGatewayMock.Setup(
                    x => x.GetJsonDataQueryAsync()
                    ).Throws(new Exception());
            var sut = new GetJsonDataQueryHandler(jsonGatewayMock.Object, loggerMock.Object);
         
            var result = await sut.Execute();
        }
    }
}