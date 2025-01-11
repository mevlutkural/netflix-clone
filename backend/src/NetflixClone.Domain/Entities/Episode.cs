namespace NetflixClone.Domain.Entities;

public class Episode : Video
{
    public int SeasonNumber { get; private set; }
    public int EpisodeNumber { get; private set; }
    public Guid SeriesId { get; private set; }
    public virtual Series Series { get; private set; }

    private Episode() : base() { }

    public Episode(
        string title,
        string description,
        string thumbnailUrl,
        string videoUrl,
        int durationInMinutes,
        DateTime releaseDate,
        string director,
        string cast,
        string[] languages,
        string[] subtitles,
        string[] videoQualities,
        int seasonNumber,
        int episodeNumber,
        Guid seriesId)
        : base(title, description, thumbnailUrl, videoUrl, durationInMinutes,
            releaseDate, director, cast, languages, subtitles, videoQualities)
    {
        SeasonNumber = seasonNumber;
        EpisodeNumber = episodeNumber;
        SeriesId = seriesId;
    }

    public void UpdateEpisodeInfo(int seasonNumber, int episodeNumber)
    {
        SeasonNumber = seasonNumber;
        EpisodeNumber = episodeNumber;
        Update();
    }
} 