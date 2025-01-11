using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Profiles.Commands.DeleteProfile;

public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfileCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _unitOfWork.Profiles.GetByIdAsync(request.Id, cancellationToken);

        if (profile == null)
        {
            return Result.Failure($"Profile with ID {request.Id} was not found.");
        }

        // Verify that the profile belongs to the user
        if (profile.UserId != request.UserId)
        {
            return Result.Failure("You are not authorized to delete this profile.");
        }

        // Check if this is the last profile
        var profileCount = await _unitOfWork.Profiles.GetProfileCountByUserIdAsync(request.UserId, cancellationToken);
        if (profileCount <= 1)
        {
            return Result.Failure("Cannot delete the last profile.");
        }

        // Soft delete the profile
        profile.Delete();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
} 