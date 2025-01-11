using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Users.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<UserAuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RefreshTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<UserAuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Validate refresh token
        if (!_jwtTokenGenerator.ValidateRefreshToken(request.RefreshToken))
        {
            return Result<UserAuthResponseDto>.Failure("Invalid refresh token.");
        }

        // Get user by refresh token
        var user = await _unitOfWork.Users.GetByRefreshTokenAsync(request.RefreshToken, cancellationToken);

        if (user == null)
        {
            return Result<UserAuthResponseDto>.Failure("Invalid refresh token.");
        }

        // Check if refresh token is expired
        if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return Result<UserAuthResponseDto>.Failure("Refresh token has expired.");
        }

        // Generate new tokens
        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        // Update user's refresh token
        user.UpdateRefreshToken(refreshToken, refreshTokenExpiryTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Create response
        var response = new UserAuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpiryTime = refreshTokenExpiryTime,
            User = _mapper.Map<UserDto>(user)
        };

        return Result<UserAuthResponseDto>.Success(response);
    }
} 