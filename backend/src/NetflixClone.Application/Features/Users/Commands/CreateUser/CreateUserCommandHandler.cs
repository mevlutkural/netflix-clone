using AutoMapper;
using MediatR;
using NetflixClone.Application.Common.Models;
using NetflixClone.Application.DTOs;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check if email is unique
        if (!await _unitOfWork.Users.IsEmailUniqueAsync(request.Email, cancellationToken))
        {
            return Result<UserDto>.Failure("Email is already in use.");
        }

        // Hash password
        var passwordHash = _passwordHasher.HashPassword(request.Password);

        // Create user
        var user = new User(
            request.Email,
            passwordHash,
            request.FirstName,
            request.LastName);

        if (request.PhoneNumber != null)
        {
            user.UpdatePhoneNumber(request.PhoneNumber);
        }

        // Save user
        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Map to DTO and return
        var userDto = _mapper.Map<UserDto>(user);
        return Result<UserDto>.Success(userDto);
    }
} 