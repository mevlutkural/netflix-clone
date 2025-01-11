using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Profiles.Queries.GetProfilesByUserId;

public class GetProfilesByUserIdQueryHandler : IRequestHandler<GetProfilesByUserIdQuery, Result<IEnumerable<ProfileDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProfilesByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ProfileDto>>> Handle(GetProfilesByUserIdQuery request, CancellationToken cancellationToken)
    {
        // Check if user exists
        var user = await _unitOfWork.Users.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return Result<IEnumerable<ProfileDto>>.Failure($"User with ID {request.UserId} was not found.");
        }

        var profiles = await _unitOfWork.Profiles.GetByUserIdAsync(request.UserId, cancellationToken);
        var profileDtos = _mapper.Map<IEnumerable<ProfileDto>>(profiles);

        return Result<IEnumerable<ProfileDto>>.Success(profileDtos);
    }
} 