using FluentValidation;

namespace NetflixClone.Application.Features.Profiles.Commands.DeleteProfile;

public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
{
    public DeleteProfileCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Profile ID is required.");

        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
} 