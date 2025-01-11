using FluentValidation;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfilesByUserId;

public class GetProfilesByUserIdQueryValidator : AbstractValidator<GetProfilesByUserIdQuery>
{
    public GetProfilesByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
} 