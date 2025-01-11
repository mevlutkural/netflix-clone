using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;

namespace NetflixClone.Application.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<Result<UserDto>>
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? PhoneNumber { get; init; }
} 