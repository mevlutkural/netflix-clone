using NetflixClone.Domain.Common;

namespace NetflixClone.Domain.Entities;

public class Profile : BaseEntity
{
    public string Name { get; private set; }
    public string? AvatarUrl { get; private set; }
    public bool IsKidsProfile { get; private set; }
    public string Language { get; private set; }
    public string? MaturityLevel { get; private set; }
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }
    public virtual ICollection<WatchHistory> WatchHistory { get; private set; }

    private Profile() : base()
    {
        WatchHistory = new List<WatchHistory>();
    }

    public Profile(string name, bool isKidsProfile, string language, Guid userId) : this()
    {
        Name = name;
        IsKidsProfile = isKidsProfile;
        Language = language;
        UserId = userId;
    }

    public void UpdateName(string name)
    {
        Name = name;
        Update();
    }

    public void UpdateAvatar(string avatarUrl)
    {
        AvatarUrl = avatarUrl;
        Update();
    }

    public void UpdateLanguage(string language)
    {
        Language = language;
        Update();
    }

    public void UpdateMaturityLevel(string maturityLevel)
    {
        MaturityLevel = maturityLevel;
        Update();
    }
} 