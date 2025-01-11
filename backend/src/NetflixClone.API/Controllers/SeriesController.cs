using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.Series.Commands.CreateSeries;
using NetflixClone.Application.Features.Series.Commands.DeleteSeries;
using NetflixClone.Application.Features.Series.Commands.UpdateSeries;
using NetflixClone.Application.Features.Series.Queries.GetSeriesById;
using NetflixClone.Application.Features.Series.Queries.GetSeries;
using NetflixClone.Application.Features.Series.Queries.GetSeriesByCategory;
using NetflixClone.Application.Features.Series.Queries.GetNewReleases;
using NetflixClone.Application.Features.Series.Queries.GetTrending;
using NetflixClone.Application.Features.Series.Queries.SearchSeries;
using NetflixClone.Application.Features.Series.Queries.GetEpisodes;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SeriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSeries([FromQuery] GetSeriesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSeries(Guid id)
    {
        var query = new GetSeriesByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetSeriesByCategory(Guid categoryId)
    {
        var query = new GetSeriesByCategoryQuery { CategoryId = categoryId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("new-releases")]
    public async Task<IActionResult> GetNewReleases([FromQuery] int count = 10)
    {
        var query = new GetNewReleasesQuery { Count = count };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("trending")]
    public async Task<IActionResult> GetTrending([FromQuery] int count = 10)
    {
        var query = new GetTrendingQuery { Count = count };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchSeries([FromQuery] string searchTerm)
    {
        var query = new SearchSeriesQuery { SearchTerm = searchTerm };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}/episodes")]
    public async Task<IActionResult> GetEpisodes(Guid id, [FromQuery] int seasonNumber)
    {
        var query = new GetEpisodesQuery { SeriesId = id, SeasonNumber = seasonNumber };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateSeries([FromBody] CreateSeriesCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetSeries), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateSeries(Guid id, [FromBody] UpdateSeriesCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSeries(Guid id)
    {
        var command = new DeleteSeriesCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 