using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.Infrastructure.Contexts
{
    public class GameSessionContext : DbContext
    {
        public GameSessionContext(DbContextOptions<GameSessionContext> options)
        : base(options) { }

        public DbSet<GameSession> GameSessions { get; set; }

        public async Task<HighLowGame.Domain.Aggregates.GameAggregate.GameSession> GetGameSessionById(Guid id)
        {
            var gameSessionEntity = await this.GameSessions.SingleAsync(p => p.Id == id);
            var gameSession = new Domain.Aggregates.GameAggregate.GameSession(gameSessionEntity.PlayerOneId, gameSessionEntity.PlayerTwoId);
            gameSession.SetPlayerOneScore(gameSessionEntity.PlayerOneScore);
            gameSession.SetPlayerTwoScore(gameSessionEntity.PlayerTwoScore);
            gameSession.SetGameFinished(gameSessionEntity.IsFinished);
            gameSession.SetGameFinishedReason(gameSessionEntity.GameEndReason);
            return gameSession;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameSession>().HasKey(x => x.Id);
            builder.Entity<GameSession>().HasIndex(p => new { p.PlayerOneId, p.PlayerTwoId }).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
