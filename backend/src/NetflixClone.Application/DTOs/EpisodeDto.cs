namespace NetflixClone.Application.DTOs;

public class EpisodeDto : VideoDto
{
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public Guid SeriesId { get; set; }
}

public class CreateEpisodeDto : CreateVideoDto
{
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public Guid SeriesId { get; set; }
}

public class UpdateEpisodeDto : UpdateVideoDto
{
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
} 