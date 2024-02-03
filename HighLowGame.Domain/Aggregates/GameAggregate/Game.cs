using HighLowGame.Domain.Interfaces;

namespace HighLowGame.Domain.Aggregates.GameAggregate;

public class Game : IEntity
{
    public Guid Id { get; private set; }
    public List<GameSession> GameSessions { get; private set; }
    public List<PlayerMove> PlayerMoves { get; private set; }

    public Game()
    {
        this.Id = Guid.NewGuid();
        this.PlayerMoves = new List<PlayerMove>();
        this.GameSessions = new List<GameSession>();
    }

    public Guid BeginNewGamesSession(Guid playerOneId, Guid playerTwoId)
    {
        var gameSession = new GameSession(playerOneId, playerTwoId);
        
        this.GameSessions.Add(gameSession);

        return gameSession.Id;
    }

    public void AddPlayerMove(PlayerMove playerMove)
    {
        this.PlayerMoves.Add(playerMove);
    }

    public void FinishGame()
    {
        // Just gonna assume there is only 1 game session to speedrun this
        this.GameSessions.First().FinishGame(null);
    }
}