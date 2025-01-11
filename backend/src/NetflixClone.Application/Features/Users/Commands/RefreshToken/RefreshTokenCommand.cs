using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Users.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<Result<UserAuthResponseDto>>
{
    public string RefreshToken { get; init; } = string.Empty;
} 