using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;

namespace NetflixClone.Application.Features.Users.Commands.AuthenticateUser;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Result<UserAuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result<UserAuthResponseDto>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        // Get user by email
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null)
        {
            return Result<UserAuthResponseDto>.Failure("Invalid email or password.");
        }

        // Verify password
        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Result<UserAuthResponseDto>.Failure("Invalid email or password.");
        }

        // Generate JWT token and refresh token
        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        // Update user's refresh token
        user.UpdateRefreshToken(refreshToken, refreshTokenExpiryTime);
        user.UpdateLastLoginDate();

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