using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.Movies.Commands.CreateMovie;
using NetflixClone.Application.Features.Movies.Commands.DeleteMovie;
using NetflixClone.Application.Features.Movies.Commands.UpdateMovie;
using NetflixClone.Application.Features.Movies.Queries.GetMovieById;
using NetflixClone.Application.Features.Movies.Queries.GetMovies;
using NetflixClone.Application.Features.Movies.Queries.GetMoviesByCategory;
using NetflixClone.Application.Features.Movies.Queries.GetNewReleases;
using NetflixClone.Application.Features.Movies.Queries.GetTrending;
using NetflixClone.Application.Features.Movies.Queries.SearchMovies;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(Guid id)
    {
        var query = new GetMovieByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetMoviesByCategory(Guid categoryId)
    {
        var query = new GetMoviesByCategoryQuery { CategoryId = categoryId };
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
    public async Task<IActionResult> SearchMovies([FromQuery] string searchTerm)
    {
        var query = new SearchMoviesQuery { SearchTerm = searchTerm };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMovie), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateMovie(Guid id, [FromBody] UpdateMovieCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        var command = new DeleteMovieCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 