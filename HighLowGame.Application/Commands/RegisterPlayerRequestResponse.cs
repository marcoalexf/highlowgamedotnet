using MediatR;

namespace HighLowGame.Application.Commands;

public class RegisterPlayerRequestResponse
{
    public Guid PlayerId { get; set; }
}