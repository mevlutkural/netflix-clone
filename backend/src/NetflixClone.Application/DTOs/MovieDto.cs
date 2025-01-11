namespace NetflixClone.Application.DTOs;

public class MovieDto : VideoDto
{
    public string TrailerUrl { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
}

public class CreateMovieDto : CreateVideoDto
{
    public string TrailerUrl { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
}

public class UpdateMovieDto : UpdateVideoDto
{
    public string TrailerUrl { get; set; } = string.Empty;
    public bool IsNewRelease { get; set; }
    public bool IsTrending { get; set; }
} 