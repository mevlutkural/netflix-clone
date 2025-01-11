namespace NetflixClone.Domain.Entities;

public class Series : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ThumbnailUrl { get; private set; }
    public string TrailerUrl { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public string Creator { get; private set; }
    public string Cast { get; private set; }
    public bool IsNewRelease { get; private set; }
    public bool IsTrending { get; private set; }
    public double Rating { get; private set; }
    public int ViewCount { get; private set; }
    public virtual ICollection<Episode> Episodes { get; private set; }
    public virtual ICollection<Category> Categories { get; private set; }

    private Series() : base()
    {
        Episodes = new List<Episode>();
        Categories = new List<Category>();
    }

    public Series(
        string title,
        string description,
        string thumbnailUrl,
        string trailerUrl,
        DateTime releaseDate,
        string creator,
        string cast,
        bool isNewRelease = false,
        bool isTrending = false) : this()
    {
        Title = title;
        Description = description;
        ThumbnailUrl = thumbnailUrl;
        TrailerUrl = trailerUrl;
        ReleaseDate = releaseDate;
        Creator = creator;
        Cast = cast;
        IsNewRelease = isNewRelease;
        IsTrending = isTrending;
        Rating = 0;
        ViewCount = 0;
    }

    public void AddEpisode(Episode episode)
    {
        Episodes.Add(episode);
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

    public void UpdateRating(double newRating)
    {
        Rating = newRating;
        Update();
    }

    public void IncrementViewCount()
    {
        ViewCount++;
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