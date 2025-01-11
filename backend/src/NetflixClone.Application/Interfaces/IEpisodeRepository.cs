using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface IEpisodeRepository : IBaseRepository<Episode>
{
    Task<IEnumerable<Episode>> GetBySeriesIdAsync(Guid seriesId, CancellationToken cancellationToken = default);
    Task<Episode?> GetBySeriesAndEpisodeNumberAsync(Guid seriesId, int seasonNumber, int episodeNumber, CancellationToken cancellationToken = default);
    Task<int> GetEpisodeCountBySeriesIdAsync(Guid seriesId, int seasonNumber, CancellationToken cancellationToken = default);
} 