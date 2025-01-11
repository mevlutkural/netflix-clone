namespace NetflixClone.Application.DTOs;

public class SeriesDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string TrailerUrl { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Creator { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
    public double Rating { get; set; }
    public int ViewCount { get; set; }
    public ICollection<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
    public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateSeriesDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string TrailerUrl { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Creator { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
    public ICollection<Guid> CategoryIds { get; set; } = new List<Guid>();
}

public class UpdateSeriesDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string TrailerUrl { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Creator { get; set; } = string.Empty;
    public string Cast { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
    public ICollection<Guid> CategoryIds { get; set; } = new List<Guid>();
} 