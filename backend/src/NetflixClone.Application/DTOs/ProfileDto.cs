namespace NetflixClone.Application.DTOs;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public bool IsKidsProfile { get; set; }
    public string Language { get; set; } = string.Empty;
    public string? MaturityLevel { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateProfileDto
{
    public string Name { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public bool IsKidsProfile { get; set; }
    public string Language { get; set; } = string.Empty;
    public string? MaturityLevel { get; set; }
}

public class UpdateProfileDto
{
    public string Name { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string Language { get; set; } = string.Empty;
    public string? MaturityLevel { get; set; }
} 