using HighLowGame.Application.Commands;
using HighLowGame.Application.Handlers;
using HighLowGame.Infrastructure.Contexts;
using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace HighLowGame.UnitTest
{
    public class Tests
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

            var mockSet = new Mock<DbSet<Player>>();

            var mockContext = new Mock<PlayerContext>();
            mockContext.Setup(m => m.Players).Returns(mockSet.Object);

            var service = new RegisterPlayerRequestHandler(mockContext.Object);

            var mockRequest = new RegisterPlayerRequestCommand()
            {
                Username = "Test",
            };

            await service.Handle(mockRequest, CancellationToken.None);

            mockContext.Verify(m => m.AddAsync(mockPlayer, It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}