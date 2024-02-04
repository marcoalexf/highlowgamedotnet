using HighLowGame.Infrastructure.Entities;

namespace HighLowGame.Infrastructure.Contexts
{
    public class GameContext : MockDB<Game>
    {
        public GameContext()  { }
    }
}
