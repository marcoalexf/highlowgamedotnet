using HighLowGame.Application.Commands;
using HighLowGame.Infrastructure.Contexts;
using HighLowGame.Infrastructure.Entities;
using MediatR;

namespace HighLowGame.Application.Handlers
{
    public class RegisterPlayerRequestHandler : IRequestHandler<RegisterPlayerRequestCommand, RegisterPlayerRequestResponse>
    {
        private readonly PlayerContext _playerContext;
        public RegisterPlayerRequestHandler(PlayerContext playerContext) 
        {
            this._playerContext = playerContext;
        }

        public async Task<RegisterPlayerRequestResponse> Handle(RegisterPlayerRequestCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = new Player()
            {
                Username = request.Username,
            };

            var response = new RegisterPlayerRequestResponse();
                
            try
            {
                await _playerContext.AddAsync(entityToAdd, cancellationToken);
            } catch (OperationCanceledException)
            {
                response.Error = new Errors.Error
                {
                    // better error handling for different cases, for now sufices
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = $"Something went wrong while adding player with username {request.Username} to the database: {nameof(OperationCanceledException)}"
                };
            }

            response.PlayerId = entityToAdd.Id;

            return response;
            
        }
    }
}
