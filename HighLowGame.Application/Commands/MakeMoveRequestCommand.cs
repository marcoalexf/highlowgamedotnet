using MediatR;

namespace HighLowGame.Application.Commands;

public class MakeMoveRequestCommand : IRequest<MakeMoveCommandRequestResponse>
{
    public string PlayerId { get; set; }
    public int? NumberGuess { get; set; }
    public bool? ChoseHigh { get; set; }
}