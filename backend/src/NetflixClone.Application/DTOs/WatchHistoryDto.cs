namespace NetflixClone.Application.DTOs;

public class WatchHistoryDto
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public Guid VideoId { get; set; }
    public int WatchedDurationInSeconds { get; set; }
    public DateTime LastWatchedAt { get; set; }
    public bool IsFinished { get; set; }
    public VideoDto Video { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateWatchHistoryDto
{
    public Guid ProfileId { get; set; }
    public Guid VideoId { get; set; }
    public int WatchedDurationInSeconds { get; set; }
    public bool IsFinished { get; set; }
}

public class UpdateWatchHistoryDto
{
    public int WatchedDurationInSeconds { get; set; }
    public bool IsFinished { get; set; }
} 