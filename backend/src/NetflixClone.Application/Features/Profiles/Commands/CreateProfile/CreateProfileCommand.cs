using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Profiles.Commands.CreateProfile;

public record CreateProfileCommand : IRequest<Result<ProfileDto>>
{
    public string Name { get; init; } = string.Empty;
    public string? AvatarUrl { get; init; }
    public bool IsKidsProfile { get; init; }
    public string Language { get; init; } = string.Empty;
    public string? MaturityLevel { get; init; }
    public Guid UserId { get; init; }
} 