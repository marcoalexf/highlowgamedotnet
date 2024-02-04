
namespace HighLowGame.Infrastructure.Entities
{
    public class Game : BaseEntity
    {
        public List<GameSession> GameSession { get; set; }
        public List<PlayerMove> PlayerMoves { get; set; }

    }
}
