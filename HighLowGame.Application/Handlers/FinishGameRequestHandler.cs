using HighLowGame.Application.Commands;
using HighLowGame.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace HighLowGame.Application.Handlers
{
    public class FinishGameRequestHandler : IRequestHandler<FinishGameRequestCommand, bool>
    {
        GameContext _gameContext;
        GameSessionContext _gameSessionContext;
        public FinishGameRequestHandler(GameContext gameContext, GameSessionContext gameSessionContext) 
        {
            this._gameContext = gameContext;
            this._gameSessionContext = gameSessionContext;
        }
        public async Task<bool> Handle(FinishGameRequestCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.GameId, out Guid gameId))
            {
                throw new ArgumentException("Not a valid Guid");
            }

            var game = await _gameContext.GetAsync(gameId);

            if (game is null)
            {
                return false;
            }

            // Assuming only one session for now..
            var gameSessionEntity = await _gameSessionContext.GetAsync(game.GameSession.First().Id);
            var gameSession = new Domain.Aggregates.GameAggregate.GameSession(gameSessionEntity.PlayerOneId, gameSessionEntity.PlayerTwoId);


            gameSession.SetPlayerOneScore(gameSessionEntity.PlayerOneScore);
            gameSession.SetPlayerTwoScore(gameSessionEntity.PlayerTwoScore);
            gameSession.SetGameFinished(gameSessionEntity.IsFinished);
            gameSession.SetGameFinishedReason(gameSessionEntity.GameEndReason);

            gameSession.FinishGame(null);
            game.GameSession.Remove(gameSessionEntity);
            game.GameSession.Add(gameSessionEntity);
            var updatedGameSession = await _gameSessionContext.UpdateAsync(gameSessionEntity);

            var updatedGame = _gameContext.UpdateAsync(game);

            // Error handling... TODO: Improve!!
            return true;
        }
    }
}
