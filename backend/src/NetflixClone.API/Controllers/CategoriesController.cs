using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.Categories.Commands.CreateCategory;
using NetflixClone.Application.Features.Categories.Commands.DeleteCategory;
using NetflixClone.Application.Features.Categories.Commands.UpdateCategory;
using NetflixClone.Application.Features.Categories.Queries.GetCategories;
using NetflixClone.Application.Features.Categories.Queries.GetCategoryById;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var query = new GetCategoriesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var query = new GetCategoryByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var command = new DeleteCategoryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 