using AutoMapper;
using BoostlingoApp.Application.Commands;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoostlingoApp.UnitTests
{
    [TestClass]
    public class InsertUserCommandHandlerTest
    {
        [TestMethod]
        public void Validate_DoesNotThrowError_WhenInsertionSuccessful()
        {
            bool isExecuted = false;
            var userRepoMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<InsertUsersCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            userRepoMock.Setup(
                    x => x.AddRange(It.IsAny<IEnumerable<UserEntity>>())
                    ).Callback(() => isExecuted = true);


            var sut = new InsertUsersCommandHandler(userRepoMock.Object, loggerMock.Object, mapperMock.Object);
            var result = sut.Execute(new List<User>());
            Assert.AreEqual(true, isExecuted);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Validate_ThrowsException_WhenInsertionNotSuccesful()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<InsertUsersCommandHandler>>();
            var mapperMock = new Mock<IMapper>();
            userRepoMock.Setup(
                    x => x.AddRange(It.IsAny<IEnumerable<UserEntity>>())
                    ).Throws(new Exception());


            var sut = new InsertUsersCommandHandler(userRepoMock.Object, loggerMock.Object, mapperMock.Object);

            var result = sut.Execute(new List<User>());

        }

    }
}
