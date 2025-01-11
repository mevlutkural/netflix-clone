using Microsoft.EntityFrameworkCore;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Repositories;

public class WatchHistoryRepository : BaseRepository<WatchHistory>, IWatchHistoryRepository
{
    public WatchHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<WatchHistory>> GetByProfileIdAsync(Guid profileId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Video)
            .Where(w => w.ProfileId == profileId)
            .OrderByDescending(w => w.LastWatchedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<WatchHistory?> GetByProfileAndVideoAsync(Guid profileId, Guid videoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Video)
            .FirstOrDefaultAsync(w => 
                w.ProfileId == profileId && 
                w.VideoId == videoId, 
                cancellationToken);
    }

    public async Task<IEnumerable<WatchHistory>> GetRecentlyWatchedAsync(Guid profileId, int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Video)
            .Where(w => w.ProfileId == profileId)
            .OrderByDescending(w => w.LastWatchedAt)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<WatchHistory>> GetContinueWatchingAsync(Guid profileId, int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Video)
            .Where(w => 
                w.ProfileId == profileId && 
                !w.IsFinished)
            .OrderByDescending(w => w.LastWatchedAt)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public override async Task<WatchHistory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(w => w.Video)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }
} 