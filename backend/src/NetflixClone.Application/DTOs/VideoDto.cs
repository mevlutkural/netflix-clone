namespace NetflixClone.Application.DTOs;

public abstract class VideoDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public string[] Languages { get; set; } = Array.Empty<string>();
    public string[] Subtitles { get; set; } = Array.Empty<string>();
    public string[] VideoQualities { get; set; } = Array.Empty<string>();
    public double Rating { get; set; }
    public int ViewCount { get; set; }
    public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public abstract class CreateVideoDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public string[] Languages { get; set; } = Array.Empty<string>();
    public string[] Subtitles { get; set; } = Array.Empty<string>();
    public string[] VideoQualities { get; set; } = Array.Empty<string>();
    public ICollection<Guid> CategoryIds { get; set; } = new List<Guid>();
}

public abstract class UpdateVideoDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public string[] Languages { get; set; } = Array.Empty<string>();
    public string[] Subtitles { get; set; } = Array.Empty<string>();
    public string[] VideoQualities { get; set; } = Array.Empty<string>();
    public ICollection<Guid> CategoryIds { get; set; } = new List<Guid>();
} 