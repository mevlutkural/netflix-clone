using MediatR;
using NetflixClone.Application.Common.Models;

namespace NetflixClone.Application.Features.Profiles.Commands.DeleteProfile;

public record DeleteProfileCommand : IRequest<Result>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }

    public DeleteProfileCommand(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
} 