namespace HighLowGame.Infrastructure.Entities
{
    public class PlayerMove : BaseEntity
    {
        public Guid PlayerId { get; private set; }
        public bool? ChooseHigher { get; private set; }
        public int? NumberChosen { get; private set; }

        public Guid? GameId { get; set; }
        public Game? Game { get; set; }
    }
}
