using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetflixClone.API.Extensions;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
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
    public async Task<ActionResult<Result<IEnumerable<ProfileDto>>>> GetProfiles()
    {
        var userId = User.GetUserId();
        var query = new GetProfilesByUserIdQuery(userId);
        var result = await _mediator.Send(query);

        if (result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<ProfileDto>>> GetProfile(Guid id)
    {
        var userId = User.GetUserId();
        var query = new GetProfileByIdQuery(id, userId);
        var result = await _mediator.Send(query);

        if (result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Result<ProfileDto>>> CreateProfile(CreateProfileDto createProfileDto)
    {
        var userId = User.GetUserId();
        var command = new CreateProfileCommand
        {
            Name = createProfileDto.Name,
            AvatarUrl = createProfileDto.AvatarUrl,
            IsKidsProfile = createProfileDto.IsKidsProfile,
            Language = createProfileDto.Language,
            MaturityLevel = createProfileDto.MaturityLevel,
            UserId = userId
        };

        var result = await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result);

        return CreatedAtAction(nameof(GetProfile), new { id = result.Data!.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Result<ProfileDto>>> UpdateProfile(Guid id, UpdateProfileDto updateProfileDto)
    {
        var command = new UpdateProfileCommand
        {
            Id = id,
            Name = updateProfileDto.Name,
            AvatarUrl = updateProfileDto.AvatarUrl,
            Language = updateProfileDto.Language,
            MaturityLevel = updateProfileDto.MaturityLevel
        };

        var result = await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result>> DeleteProfile(Guid id)
    {
        var userId = User.GetUserId();
        var command = new DeleteProfileCommand(id, userId);
        var result = await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }
} 