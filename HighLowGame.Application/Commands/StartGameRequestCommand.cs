using MediatR;

namespace HighLowGame.Application.Commands;

public class StartGameRequestCommand : IRequest<StartGameRequestResponse>
{
    public string PlayerOneId { get; set; }
    public string PlayerTwoId { get; set; }
}