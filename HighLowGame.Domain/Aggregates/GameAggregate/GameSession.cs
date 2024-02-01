namespace HighLowGame.Domain.Aggregates.GameAggregate;

public class GameSession
{
    public Guid Id { get; private set; }
    public Guid PlayerOneId { get; private set; }
    public Guid PlayerTwoId { get; private set; }
    public int PlayerOneScore { get; private set; }
    public int PlayerTwoScore { get; private set; }
    public bool IsFinished { get; private set; }
    public GameEndReason GameEndReason { get; private set; }

    public GameSession(Guid playerOneId, Guid playerTwoId)
    {
        this.Id = Guid.NewGuid();
        this.PlayerOneId = playerOneId;
        this.PlayerTwoId = playerTwoId;
        this.PlayerOneScore = 0;
        this.PlayerTwoScore = 0;
        this.IsFinished = false;
    }

    public void SetPlayerOneScore(int score)
    {
        this.PlayerOneScore = score;
    }
    
    public void SetPlayerTwoScore(int score)
    {
        this.PlayerTwoScore = score;
    }

    public void FinishGame(GameEndReason? reason)
    {
        this.IsFinished = true;
        this.GameEndReason = reason ?? GameEndReason.PlayerWon;
    }
}