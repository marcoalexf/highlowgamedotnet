using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.Infrastructure.Contexts
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options)
        : base(options) { }

        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>().HasKey(x => x.Id);
            builder.Entity<Player>().HasIndex(p => p.Username).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
