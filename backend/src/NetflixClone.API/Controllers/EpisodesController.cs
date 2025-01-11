using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.Episodes.Commands.CreateEpisode;
using NetflixClone.Application.Features.Episodes.Commands.DeleteEpisode;
using NetflixClone.Application.Features.Episodes.Commands.UpdateEpisode;
using NetflixClone.Application.Features.Episodes.Queries.GetEpisodeById;
using NetflixClone.Application.Features.Episodes.Queries.GetEpisodesBySeriesId;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EpisodesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EpisodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEpisode(Guid id)
    {
        var query = new GetEpisodeByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("series/{seriesId}")]
    public async Task<IActionResult> GetEpisodesBySeries(Guid seriesId)
    {
        var query = new GetEpisodesBySeriesIdQuery { SeriesId = seriesId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateEpisode([FromBody] CreateEpisodeCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetEpisode), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateEpisode(Guid id, [FromBody] UpdateEpisodeCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteEpisode(Guid id)
    {
        var command = new DeleteEpisodeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 