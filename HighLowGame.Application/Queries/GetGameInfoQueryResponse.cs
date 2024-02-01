namespace HighLowGame.Application.Queries;

public class GetGameInfoQueryResponse
{
    public string Id { get; private set; }
    public List<string> GameSessions { get; private set; }
    public List<string> PlayerMoves { get; private set; }
}