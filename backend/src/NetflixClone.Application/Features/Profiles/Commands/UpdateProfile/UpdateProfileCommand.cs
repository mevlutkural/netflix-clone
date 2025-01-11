using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Profiles.Commands.UpdateProfile;

public record UpdateProfileCommand : IRequest<Result<ProfileDto>>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? AvatarUrl { get; init; }
    public string Language { get; init; } = string.Empty;
    public string? MaturityLevel { get; init; }
} 