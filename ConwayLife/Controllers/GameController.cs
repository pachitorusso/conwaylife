using ConwayLife.Application;
using ConwayLife.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConwayLife.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
    private IGameUseCase _gameUseCase;

    public GameController(IGameUseCase gameUseCase)
    {
        _gameUseCase = gameUseCase;
    }

    [HttpGet]
    [Route("NextState/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> NextState(Guid id)
    {
        try
        {
            var game = await _gameUseCase.NextState(id);
        
            if (game is null)
            {
                return Conflict($"No game found for id {id}");
            }
        
            return Ok(game.ToString());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("NextStateGivenSteps/{id}/{steps}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> GetStateGivenSteps(Guid id, int steps)
    {
        try
        {
            var game = await _gameUseCase.GetStateAway(id,steps);
        
            if (game is null)
            {
                return Conflict($"No game found for id {id}");
            }
        
            return Ok(game.ToString());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("FinalState")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    public async Task<IActionResult> FinalState([FromBody] ExpectedStateRequest request)
    {
        try
        {
            var game = await _gameUseCase.IsFinalState(request.Id, request.AliveCells, request.Steps);
        
            if (game is null)
            {
                return Conflict($"No game found for id {request.Id}");
            }
        
            return Ok(game.ToString());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }    
    
    [HttpPost(Name="Post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Post([FromBody] InputGameDTO game)
    {
        try
        {
            var gameId = await _gameUseCase.CreateGame(game.BoardSize, game.AliveCells);

            return Ok(gameId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}