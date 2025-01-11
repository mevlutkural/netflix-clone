using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfileById;

public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, Result<ProfileDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProfileByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProfileDto>> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var profile = await _unitOfWork.Profiles.GetByIdAsync(request.Id, cancellationToken);

        if (profile == null)
        {
            return Result<ProfileDto>.Failure($"Profile with ID {request.Id} was not found.");
        }

        // Verify that the profile belongs to the user
        if (profile.UserId != request.UserId)
        {
            return Result<ProfileDto>.Failure("You are not authorized to view this profile.");
        }

        var profileDto = _mapper.Map<ProfileDto>(profile);
        return Result<ProfileDto>.Success(profileDto);
    }
} 