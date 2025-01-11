using Microsoft.EntityFrameworkCore;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Movie>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Categories)
            .Where(m => m.Categories.Any(c => c.Id == categoryId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> GetNewReleasesAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Categories)
            .Where(m => m.IsNewRelease)
            .OrderByDescending(m => m.ReleaseDate)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> GetTrendingAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Categories)
            .Where(m => m.IsTrending)
            .OrderByDescending(m => m.ViewCount)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Categories)
            .Where(m => m.Title.Contains(searchTerm) || m.Description.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }

    public override async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(m => m.Categories)
            .Include(m => m.WatchHistory)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }
} 