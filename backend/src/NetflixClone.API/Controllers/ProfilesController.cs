using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.Application.Features.Profiles.Commands.CreateProfile;
using NetflixClone.Application.Features.Profiles.Commands.DeleteProfile;
using NetflixClone.Application.Features.Profiles.Commands.UpdateProfile;
using NetflixClone.Application.Features.Profiles.Queries.GetProfileById;
using NetflixClone.Application.Features.Profiles.Queries.GetProfilesByUserId;

namespace NetflixClone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfiles()
    {
        var query = new GetProfilesByUserIdQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfile(Guid id)
    {
        var query = new GetProfileByIdQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProfile), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfile(Guid id, [FromBody] UpdateProfileCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfile(Guid id)
    {
        var command = new DeleteProfileCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
} 