using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.Infrastructure.Contexts
{
    public class GameSessionContext : DbContext
    {
        public GameSessionContext(DbContextOptions<GameSessionContext> options)
        : base(options) { }

        public DbSet<GameSession> GameSessions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameSession>().HasKey(x => x.Id);
            builder.Entity<GameSession>().HasIndex(p => new { p.PlayerOneId, p.PlayerTwoId }).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
