using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface IMovieRepository : IBaseRepository<Movie>
{
    Task<IEnumerable<Movie>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetNewReleasesAsync(int count, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetTrendingAsync(int count, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default);
} 