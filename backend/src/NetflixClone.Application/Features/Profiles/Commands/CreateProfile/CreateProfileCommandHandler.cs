using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Features.Profiles.Commands.CreateProfile;

public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Result<ProfileDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProfileDto>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        // Check if user exists
        var user = await _unitOfWork.Users.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return Result<ProfileDto>.Failure($"User with ID {request.UserId} was not found.");
        }

        // Check profile limit (e.g., maximum 5 profiles per user)
        var profileCount = await _unitOfWork.Profiles.GetProfileCountByUserIdAsync(request.UserId, cancellationToken);
        if (profileCount >= 5)
        {
            return Result<ProfileDto>.Failure("Maximum number of profiles reached for this user.");
        }

        // Create profile
        var profile = new Profile(
            request.Name,
            request.IsKidsProfile,
            request.Language,
            request.UserId);

        if (request.AvatarUrl != null)
        {
            profile.UpdateAvatar(request.AvatarUrl);
        }

        if (request.MaturityLevel != null)
        {
            profile.UpdateMaturityLevel(request.MaturityLevel);
        }

        // Save profile
        await _unitOfWork.Profiles.AddAsync(profile, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Map to DTO and return
        var profileDto = _mapper.Map<ProfileDto>(profile);
        return Result<ProfileDto>.Success(profileDto);
    }
} 