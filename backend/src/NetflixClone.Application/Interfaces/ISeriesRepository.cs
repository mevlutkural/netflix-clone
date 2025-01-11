using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface ISeriesRepository : IBaseRepository<Series>
{
    Task<IEnumerable<Series>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Series>> GetNewReleasesAsync(int count, CancellationToken cancellationToken = default);
    Task<IEnumerable<Series>> GetTrendingAsync(int count, CancellationToken cancellationToken = default);
    Task<IEnumerable<Series>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default);
    Task<IEnumerable<Episode>> GetEpisodesAsync(Guid seriesId, int seasonNumber, CancellationToken cancellationToken = default);
} 