using NetflixClone.Domain.Common;

namespace NetflixClone.Domain.Entities;

public class WatchHistory : BaseEntity
{
    public Guid ProfileId { get; private set; }
    public Guid VideoId { get; private set; }
    public int WatchedDurationInSeconds { get; private set; }
    public DateTime LastWatchedAt { get; private set; }
    public bool IsFinished { get; private set; }
    public virtual Profile Profile { get; private set; }
    public virtual Video Video { get; private set; }

    private WatchHistory() : base() { }

    public WatchHistory(Guid profileId, Guid videoId) : this()
    {
        ProfileId = profileId;
        VideoId = videoId;
        WatchedDurationInSeconds = 0;
        LastWatchedAt = DateTime.UtcNow;
        IsFinished = false;
    }

    public void UpdateProgress(int watchedDurationInSeconds, bool isFinished = false)
    {
        WatchedDurationInSeconds = watchedDurationInSeconds;
        IsFinished = isFinished;
        LastWatchedAt = DateTime.UtcNow;
        Update();
    }

    public void MarkAsFinished()
    {
        IsFinished = true;
        LastWatchedAt = DateTime.UtcNow;
        Update();
    }
} 