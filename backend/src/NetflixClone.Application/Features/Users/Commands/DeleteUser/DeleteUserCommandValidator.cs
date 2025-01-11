using FluentValidation;

namespace NetflixClone.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("User ID is required.");
    }
} 