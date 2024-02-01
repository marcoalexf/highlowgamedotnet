using MediatR;

namespace HighLowGame.Application.Commands;

public class RegisterPlayerRequestCommand: IRequest<RegisterPlayerRequestResponse>
{
    public string Username { get; set; }
}