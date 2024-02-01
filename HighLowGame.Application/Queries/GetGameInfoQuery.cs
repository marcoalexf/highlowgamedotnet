using MediatR;

namespace HighLowGame.Application.Queries;

public class GetGameInfoQuery : IRequest<GetGameInfoQueryResponse>
{
    public string GameId { get; set; }
}