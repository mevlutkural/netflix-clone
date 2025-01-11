using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfileById;

public record GetProfileByIdQuery : IRequest<Result<ProfileDto>>
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }

    public GetProfileByIdQuery(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
} 