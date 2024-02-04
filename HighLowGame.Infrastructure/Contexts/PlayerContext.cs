using HighLowGame.Infrastructure.Entities;

namespace HighLowGame.Infrastructure.Contexts
{
    public class PlayerContext : MockDB<Player>
    {
        public PlayerContext() { }
    }
}
