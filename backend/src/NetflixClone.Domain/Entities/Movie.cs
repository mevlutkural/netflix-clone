namespace NetflixClone.Domain.Entities;

public class Movie : Video
{
    public string TrailerUrl { get; private set; }
    public bool IsNewRelease { get; private set; }
    public bool IsTrending { get; private set; }

    private Movie() : base() { }

    public Movie(
        string title,
        string description,
        string thumbnailUrl,
        string videoUrl,
        string trailerUrl,
        int durationInMinutes,
        DateTime releaseDate,
        string director,
        string cast,
        string[] languages,
        string[] subtitles,
        string[] videoQualities,
        bool isNewRelease = false,
        bool isTrending = false) 
        : base(title, description, thumbnailUrl, videoUrl, durationInMinutes, 
            releaseDate, director, cast, languages, subtitles, videoQualities)
    {
        TrailerUrl = trailerUrl;
        IsNewRelease = isNewRelease;
        IsTrending = isTrending;
    }

    public void UpdateTrailer(string trailerUrl)
    {
        TrailerUrl = trailerUrl;
        Update();
    }

    public void SetNewRelease(bool isNewRelease)
    {
        IsNewRelease = isNewRelease;
        Update();
    }

    public void SetTrending(bool isTrending)
    {
        IsTrending = isTrending;
        Update();
    }
} 