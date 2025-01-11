using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Profiles.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Result<ProfileDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProfileDto>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _unitOfWork.Profiles.GetByIdAsync(request.Id, cancellationToken);

        if (profile == null)
        {
            return Result<ProfileDto>.Failure($"Profile with ID {request.Id} was not found.");
        }

        // Update profile properties
        profile.UpdateName(request.Name);
        profile.UpdateLanguage(request.Language);

        if (request.AvatarUrl != null)
        {
            profile.UpdateAvatar(request.AvatarUrl);
        }

        if (request.MaturityLevel != null)
        {
            profile.UpdateMaturityLevel(request.MaturityLevel);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var profileDto = _mapper.Map<ProfileDto>(profile);
        return Result<ProfileDto>.Success(profileDto);
    }
} 