using FluentValidation;

namespace NetflixClone.Application.Features.Profiles.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Profile ID is required.");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Profile name is required.")
            .MaximumLength(50).WithMessage("Profile name must not exceed 50 characters.");

        RuleFor(v => v.AvatarUrl)
            .MaximumLength(2000).WithMessage("Avatar URL must not exceed 2000 characters.")
            .Must(uri => string.IsNullOrEmpty(uri) || Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Avatar URL must be a valid URL.")
            .When(v => !string.IsNullOrEmpty(v.AvatarUrl));

        RuleFor(v => v.Language)
            .NotEmpty().WithMessage("Language is required.")
            .MaximumLength(10).WithMessage("Language code must not exceed 10 characters.");

        RuleFor(v => v.MaturityLevel)
            .MaximumLength(20).WithMessage("Maturity level must not exceed 20 characters.")
            .When(v => !string.IsNullOrEmpty(v.MaturityLevel));
    }
} 