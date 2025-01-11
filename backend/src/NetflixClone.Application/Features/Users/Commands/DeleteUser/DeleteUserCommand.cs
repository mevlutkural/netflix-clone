using MediatR;
using NetflixClone.Application.Common.Models;

namespace NetflixClone.Application.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand : IRequest<Result>
{
    public Guid Id { get; init; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
} 