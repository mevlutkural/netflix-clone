using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfilesByUserId;

public record GetProfilesByUserIdQuery : IRequest<Result<IEnumerable<ProfileDto>>>
{
    public Guid UserId { get; init; }

    public GetProfilesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
} 