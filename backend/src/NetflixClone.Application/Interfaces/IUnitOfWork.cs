namespace NetflixClone.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProfileRepository Profiles { get; }
    IMovieRepository Movies { get; }
    ISeriesRepository Series { get; }
    IEpisodeRepository Episodes { get; }
    ICategoryRepository Categories { get; }
    IWatchHistoryRepository WatchHistory { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
} 