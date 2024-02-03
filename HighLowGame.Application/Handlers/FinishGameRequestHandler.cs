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
            // Code below is experimental. Never shared a transaction between different contexts. According to Dr.Google this might be possible if the DB shares a single connection. No time to implemment.
            using var gameTransaction = _gameContext.Database.BeginTransaction();
            var game = await _gameContext.Games.SingleAsync(p => p.Id.Equals(request.GameId));
            // Assuming only one session for now..
            var gameSessionEntity = game.GameSession.First();
            var gameSession = await _gameSessionContext.GetGameSessionById(gameSessionEntity.Id);
            try
            {
                using var gameSessionTransaction = _gameContext.Database.BeginTransaction();
                {
                    try
                    {
                        gameSession.FinishGame(null);
                        game.GameSession.Remove(gameSessionEntity);
                        game.GameSession.Add(gameSessionEntity);
                        _gameSessionContext.Update(gameSessionEntity);
                        _gameSessionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // Better error handling
                        return false;
                    }
                }

                _gameContext.Update(gameSession);
                _gameContext.SaveChanges();
                gameTransaction.Commit();
            }
            catch (Exception ex)
            {
                // Better error handling
                return false;
            }

            // Error handling... TODO: Improve!!
            return true;
        }
    }
}
