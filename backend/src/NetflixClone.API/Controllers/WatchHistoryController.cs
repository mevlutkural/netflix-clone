using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.WatchHistory.Commands.CreateWatchHistory;
using NetflixClone.Application.Features.WatchHistory.Commands.DeleteWatchHistory;
using NetflixClone.Application.Features.WatchHistory.Commands.UpdateWatchHistory;
using NetflixClone.Application.Features.WatchHistory.Queries.GetContinueWatching;
using NetflixClone.Application.Features.WatchHistory.Queries.GetRecentlyWatched;
using NetflixClone.Application.Features.WatchHistory.Queries.GetWatchHistoryByProfile;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WatchHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public WatchHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("profile/{profileId}")]
    public async Task<IActionResult> GetWatchHistoryByProfile(Guid profileId)
    {
        var query = new GetWatchHistoryByProfileQuery { ProfileId = profileId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("recently-watched")]
    public async Task<IActionResult> GetRecentlyWatched([FromQuery] Guid profileId, [FromQuery] int count = 10)
    {
        var query = new GetRecentlyWatchedQuery { ProfileId = profileId, Count = count };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("continue-watching")]
    public async Task<IActionResult> GetContinueWatching([FromQuery] Guid profileId, [FromQuery] int count = 10)
    {
        var query = new GetContinueWatchingQuery { ProfileId = profileId, Count = count };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWatchHistory([FromBody] CreateWatchHistoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWatchHistory(Guid id, [FromBody] UpdateWatchHistoryCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWatchHistory(Guid id)
    {
        var command = new DeleteWatchHistoryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 