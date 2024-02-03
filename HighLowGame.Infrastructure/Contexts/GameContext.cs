using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.Infrastructure.Contexts
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
        : base(options) { }

        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>().HasKey(x => x.Id);
            builder.Entity<Game>().HasMany(p => p.GameSession).WithOne(p => p.Game).HasForeignKey(p => p.GameId);
            builder.Entity<Game>().HasMany(p => p.PlayerMoves).WithOne(p => p.Game).HasForeignKey(p => p.GameId);
            base.OnModelCreating(builder);
        }
    }
}
