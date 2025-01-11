using FluentValidation;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfileById;

public class GetProfileByIdQueryValidator : AbstractValidator<GetProfileByIdQuery>
{
    public GetProfileByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Profile ID is required.");

        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
} 