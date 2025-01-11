using Microsoft.EntityFrameworkCore;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Repositories;

public class SeriesRepository : BaseRepository<Series>, ISeriesRepository
{
    public SeriesRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Series>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.Categories)
            .Include(s => s.Episodes)
            .Where(s => s.Categories.Any(c => c.Id == categoryId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Series>> GetNewReleasesAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.Categories)
            .Include(s => s.Episodes)
            .Where(s => s.IsNewRelease)
            .OrderByDescending(s => s.ReleaseDate)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Series>> GetTrendingAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.Categories)
            .Include(s => s.Episodes)
            .Where(s => s.IsTrending)
            .OrderByDescending(s => s.ViewCount)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Series>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.Categories)
            .Include(s => s.Episodes)
            .Where(s => s.Title.Contains(searchTerm) || s.Description.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Episode>> GetEpisodesAsync(Guid seriesId, int seasonNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Episodes
            .Where(e => e.SeriesId == seriesId && e.SeasonNumber == seasonNumber)
            .OrderBy(e => e.EpisodeNumber)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Series?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.Categories)
            .Include(s => s.Episodes)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
} 