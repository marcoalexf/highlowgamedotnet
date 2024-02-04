using HighLowGame.Application.Errors;
using MediatR;

namespace HighLowGame.Application.Commands;

public class RegisterPlayerRequestResponse : IWithOptionalError
{
    public Guid PlayerId { get; set; }
    public Error? Error { get; set; }
}