using HighLowGame.Application.Commands;
using HighLowGame.Application.Handlers;
using HighLowGame.Infrastructure.Contexts;
using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace HighLowGame.UnitTest
{
    public class FinishGameRequestHandlerTests
    {
        [Test]
        public async Task ShouldFinishTheGameGivenCorrectId()
        {
            var mockId = Guid.NewGuid();

            var mockGameSession = new GameSession()
            {
                Id = Guid.NewGuid(),
                IsFinished = false,
            };

            var mockGameSessionList = new List<GameSession>() {  mockGameSession };

            var mockGame = new Game()
            {
                Id = mockId,
                GameSession = mockGameSessionList
            };

            var mockGameSessionContext = new Mock<GameSessionContext>();
            var mockGameContext = new Mock<GameContext>();
            mockGameSessionContext.Setup(m => m.GetAsync(It.IsAny<Guid>())).ReturnsAsync(mockGameSessionList.First());
            mockGameContext.Setup(m => m.GetAsync(It.IsAny<Guid>())).ReturnsAsync(mockGame);

            var service = new FinishGameRequestHandler(mockGameContext.Object, mockGameSessionContext.Object);

            var mockRequest = new FinishGameRequestCommand()
            {
                GameId = mockId.ToString(),
            };

            var result = await service.Handle(mockRequest, CancellationToken.None);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ShouldFailWithExceptionIfNotGuid()
        {
            var mockId = Guid.NewGuid();

            var mockGameSession = new GameSession()
            {
                Id = Guid.NewGuid(),
                IsFinished = false,
            };

            var mockGameSessionList = new List<GameSession>() { mockGameSession };

            var mockGame = new Game()
            {
                Id = mockId,
                GameSession = mockGameSessionList
            };

            var mockGameSessionContext = new Mock<GameSessionContext>();
            var mockGameContext = new Mock<GameContext>();
            mockGameSessionContext.Setup(m => m.GetAsync(It.IsAny<Guid>())).ReturnsAsync(mockGameSessionList.First());
            mockGameContext.Setup(m => m.GetAsync(It.IsAny<Guid>())).ReturnsAsync(mockGame);

            var service = new FinishGameRequestHandler(mockGameContext.Object, mockGameSessionContext.Object);

            var mockRequest = new FinishGameRequestCommand()
            {
                GameId = "some bad guid",
            };

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await service.Handle(mockRequest, CancellationToken.None);
            });
        }

        [Test]
        public async Task ShouldReturnFalseIfGameWithIdDoesNotExist()
        {
            var mockId = Guid.NewGuid();

            var mockGameSession = new GameSession()
            {
                Id = Guid.NewGuid(),
                IsFinished = false,
            };

            var mockGameSessionList = new List<GameSession>() { mockGameSession };

            var mockGame = new Game()
            {
                Id = mockId,
                GameSession = mockGameSessionList
            };

            var mockGameSessionContext = new Mock<GameSessionContext>();
            var mockGameContext = new Mock<GameContext>();
            mockGameSessionContext.Setup(m => m.GetAsync(It.IsAny<Guid>())).ReturnsAsync(mockGameSessionList.First());

            var service = new FinishGameRequestHandler(mockGameContext.Object, mockGameSessionContext.Object);

            Guid badGuid = Guid.NewGuid();

            while(badGuid.ToString().Equals(mockId.ToString()))
            {
                badGuid = Guid.NewGuid();
            }

            var mockRequest = new FinishGameRequestCommand()
            {
                GameId = badGuid.ToString(),
            };

            var result = await service.Handle(mockRequest, CancellationToken.None);

            Assert.IsFalse(result);
        }
    }
}