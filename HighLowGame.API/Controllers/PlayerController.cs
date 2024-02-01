using HighLowGame.API.dtos;
using HighLowGame.Application.Commands;
using HighLowGame.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HighLowGame.API.Controllers;

[Route("[controller]/[action]")]
public class PlayerController : Controller
{
    private readonly IMediator _mediator;
    public PlayerController(IMediator mediator)
    {
        this._mediator = mediator ?? throw new ArgumentException("Mediator not present in IOC container.");
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> RegisterPlayer(RegisterPlayerRequestDto playerRequestDto)
    {
        var command = new RegisterPlayerRequestCommand()
        {
            Username = playerRequestDto.Username
        };
        var result = await this._mediator.Send(command);
        return new OkResult();
    }

    [HttpPost("/{id}/info")]
    public async Task<IActionResult> GetPlayerInfo(string id)
    {
        var query = new GetPlayerInfoQuery
        {
            Id = id
        };
        var result = await this._mediator.Send(query);
        return new OkObjectResult(result);
    }
}