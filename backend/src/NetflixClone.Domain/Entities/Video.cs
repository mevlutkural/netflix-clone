using NetflixClone.Domain.Common;

namespace NetflixClone.Domain.Entities;

public abstract class Video : BaseEntity
{
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public string ThumbnailUrl { get; protected set; }
    public string VideoUrl { get; protected set; }
    public int DurationInMinutes { get; protected set; }
    public DateTime ReleaseDate { get; protected set; }
    public string Director { get; protected set; }
    public string Cast { get; protected set; }
    public string[] Languages { get; protected set; }
    public string[] Subtitles { get; protected set; }
    public string[] VideoQualities { get; protected set; }
    public double Rating { get; protected set; }
    public int ViewCount { get; protected set; }
    public virtual ICollection<Category> Categories { get; protected set; }
    public virtual ICollection<WatchHistory> WatchHistory { get; protected set; }

    protected Video() : base()
    {
        Categories = new List<Category>();
        WatchHistory = new List<WatchHistory>();
        Languages = Array.Empty<string>();
        Subtitles = Array.Empty<string>();
        VideoQualities = Array.Empty<string>();
    }

    protected Video(
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
        string[] videoQualities) : this()
    {
        Title = title;
        Description = description;
        ThumbnailUrl = thumbnailUrl;
        VideoUrl = videoUrl;
        DurationInMinutes = durationInMinutes;
        ReleaseDate = releaseDate;
        Director = director;
        Cast = cast;
        Languages = languages;
        Subtitles = subtitles;
        VideoQualities = videoQualities;
        Rating = 0;
        ViewCount = 0;
    }

    public void IncrementViewCount()
    {
        ViewCount++;
        Update();
    }

    public void UpdateRating(double newRating)
    {
        Rating = newRating;
        Update();
    }

    public void AddCategory(Category category)
    {
        Categories.Add(category);
        Update();
    }

    public void RemoveCategory(Category category)
    {
        Categories.Remove(category);
        Update();
    }
} 