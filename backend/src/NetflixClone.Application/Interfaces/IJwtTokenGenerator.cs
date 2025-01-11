using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    bool ValidateAccessToken(string token);
    bool ValidateRefreshToken(string token);
    string GetUserIdFromToken(string token);
} 