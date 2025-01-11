using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface IWatchHistoryRepository : IBaseRepository<WatchHistory>
{
    Task<IEnumerable<WatchHistory>> GetByProfileIdAsync(Guid profileId, CancellationToken cancellationToken = default);
    Task<WatchHistory?> GetByProfileAndVideoAsync(Guid profileId, Guid videoId, CancellationToken cancellationToken = default);
    Task<IEnumerable<WatchHistory>> GetRecentlyWatchedAsync(Guid profileId, int count, CancellationToken cancellationToken = default);
    Task<IEnumerable<WatchHistory>> GetContinueWatchingAsync(Guid profileId, int count, CancellationToken cancellationToken = default);
} 