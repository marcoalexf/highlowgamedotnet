using HighLowGame.Domain.Aggregates.GameAggregate;

namespace HighLowGame.Infrastructure.Entities
{
    public class GameSession : BaseEntity
    {
        public Guid PlayerOneId { get; set; }
        public Guid PlayerTwoId { get; set;}

        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
        public bool IsFinished { get; set; }

        public GameEndReason GameEndReason { get; set; }

        public Guid? GameId { get; set; }
        public Game? Game { get; set; }
    }
}
