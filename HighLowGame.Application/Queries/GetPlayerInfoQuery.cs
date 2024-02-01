using MediatR;

namespace HighLowGame.Application.Queries;

public class GetPlayerInfoQuery : IRequest<PlayerInfoQueryResponse>
{
    public string Id { get; set; }
}