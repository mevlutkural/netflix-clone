using NetflixClone.Domain.Common;

namespace NetflixClone.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime? LastLoginDate { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiryTime { get; private set; }
    public virtual ICollection<Profile> Profiles { get; private set; }

    private User() : base()
    {
        Profiles = new List<Profile>();
    }

    public User(string email, string passwordHash, string firstName, string lastName) : this()
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        IsEmailVerified = false;
    }

    public void VerifyEmail()
    {
        IsEmailVerified = true;
        Update();
    }

    public void UpdateRefreshToken(string refreshToken, DateTime expiryTime)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = expiryTime;
        Update();
    }

    public void UpdateLastLoginDate()
    {
        LastLoginDate = DateTime.UtcNow;
        Update();
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        Update();
    }

    public void AddProfile(Profile profile)
    {
        Profiles.Add(profile);
        Update();
    }
} 