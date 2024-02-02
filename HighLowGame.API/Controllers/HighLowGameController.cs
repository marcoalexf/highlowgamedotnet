using HighLowGame.API.dtos;
using HighLowGame.Application.Commands;
using HighLowGame.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HighLowGame.API.Controllers;

[Route("api/[controller]")]
public class HighLowGameController : Controller
{
    private readonly IMediator _mediator;
    public HighLowGameController(IMediator mediator)
    {
        this._mediator = mediator ?? throw new ArgumentException("Mediator not present in IOC container");
    }
    
    [HttpPost("start")]
    [ProducesResponseType(typeof(StartGameRequestResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> StartGame(StartGameRequestDto startGameRequestDto)
    {
        var command = new StartGameRequestCommand
        {
            PlayerOneId = startGameRequestDto.PlayerOneId,
            PlayerTwoId = startGameRequestDto.PlayerTwoId
        };
        var result = await this._mediator.Send(command);
        return new OkObjectResult(result);
    }

    [HttpPost("move")]
    [ProducesResponseType(typeof(MakeMoveCommandRequestResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MakeMove(MakeMoveGameRequestDto makeMoveGameRequestDto)
    {
        var command = new MakeMoveRequestCommand
        {
            PlayerId = makeMoveGameRequestDto.PlayerId,
            NumberGuess = makeMoveGameRequestDto.NumberGuess,
            ChoseHigh = makeMoveGameRequestDto.ChoseHigh
        };
        var result = await this._mediator.Send(command);
        return new OkResult();
    }

    [HttpGet("{id}/info")]
    [ProducesResponseType(typeof(GetGameInfoQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGameInfo(string id)
    {
        var query = new GetGameInfoQuery
        {
            GameId = id
        };
        var result = await this._mediator.Send(query);

        return new OkObjectResult(result);
    }
}