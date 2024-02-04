using HighLowGame.Application.Commands;
using HighLowGame.Application.Handlers;
using HighLowGame.Infrastructure.Contexts;
using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace HighLowGame.UnitTest
{
    public class AddPlayerRequestHanlderTests
    {
        [Test]
        public async Task ShouldReturnUserIdByRegisteringUserCorrectly()
        {
            var mockId = Guid.NewGuid();

            var mockPlayer = new Player()
            {
                Id = mockId,
                Username = "Test",
            };

            var data = new List<Player>
            {
                mockPlayer
            };

            var mockSet = new Mock<List<Player>>();

            var mockContext = new Mock<PlayerContext>();
            mockContext.Setup(m => m.AddAsync(It.IsAny<Player>())).ReturnsAsync(mockPlayer);

            var service = new RegisterPlayerRequestHandler(mockContext.Object);

            var mockRequest = new RegisterPlayerRequestCommand()
            {
                Username = "Test",
            };

            var result = await service.Handle(mockRequest, CancellationToken.None);

            Assert.AreEqual(result.PlayerId, mockPlayer.Id);
        }
    }
}