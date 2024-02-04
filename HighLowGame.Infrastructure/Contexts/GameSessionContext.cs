using HighLowGame.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HighLowGame.Infrastructure.Contexts
{
    public class GameSessionContext : MockDB<GameSession>
    {
        public GameSessionContext() { }
    }
}
