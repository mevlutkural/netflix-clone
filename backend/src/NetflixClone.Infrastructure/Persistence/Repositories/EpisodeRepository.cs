using Microsoft.EntityFrameworkCore;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Repositories;

public class EpisodeRepository : BaseRepository<Episode>, IEpisodeRepository
{
    public EpisodeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Episode>> GetBySeriesIdAsync(Guid seriesId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(e => e.Categories)
            .Include(e => e.WatchHistory)
            .Where(e => e.SeriesId == seriesId)
            .OrderBy(e => e.SeasonNumber)
            .ThenBy(e => e.EpisodeNumber)
            .ToListAsync(cancellationToken);
    }

    public async Task<Episode?> GetBySeriesAndEpisodeNumberAsync(Guid seriesId, int seasonNumber, int episodeNumber, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(e => e.Categories)
            .Include(e => e.WatchHistory)
            .FirstOrDefaultAsync(e => 
                e.SeriesId == seriesId && 
                e.SeasonNumber == seasonNumber && 
                e.EpisodeNumber == episodeNumber, 
                cancellationToken);
    }

    public async Task<int> GetEpisodeCountBySeriesIdAsync(Guid seriesId, int seasonNumber, CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(e => 
            e.SeriesId == seriesId && 
            e.SeasonNumber == seasonNumber, 
            cancellationToken);
    }

    public override async Task<Episode?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(e => e.Categories)
            .Include(e => e.WatchHistory)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
} 