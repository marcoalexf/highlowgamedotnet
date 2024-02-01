namespace HighLowGame.Domain.Aggregates.GameAggregate;

public class PlayerMove
{
    public Guid Id { get; private set; }
    public Guid PlayerId { get; private set; }
    public bool? ChooseHigher { get; private set; }
    public int? NumberChosen { get; private set; }

    public PlayerMove(Guid playerId)
    {
        this.Id = Guid.NewGuid();
        this.PlayerId = playerId;
    }

    public void PlayerChoseHigher()
    {
        this.ChooseHigher = true;
    }
    
    public void PlayerChoseLower()
    {
        this.ChooseHigher = false;
    }
    
    public void PlayerChoseNumber(int number)
    {
        this.NumberChosen = number;
    }
}