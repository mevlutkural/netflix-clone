using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<Result<UserDto>>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? PhoneNumber { get; init; }
} 