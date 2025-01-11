using NetflixClone.Application.Interfaces;
using NetflixClone.Infrastructure.Persistence.Repositories;

namespace NetflixClone.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IUserRepository? _userRepository;
    private IProfileRepository? _profileRepository;
    private IMovieRepository? _movieRepository;
    private ISeriesRepository? _seriesRepository;
    private IEpisodeRepository? _episodeRepository;
    private ICategoryRepository? _categoryRepository;
    private IWatchHistoryRepository? _watchHistoryRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public IProfileRepository Profiles => _profileRepository ??= new ProfileRepository(_context);
    public IMovieRepository Movies => _movieRepository ??= new MovieRepository(_context);
    public ISeriesRepository Series => _seriesRepository ??= new SeriesRepository(_context);
    public IEpisodeRepository Episodes => _episodeRepository ??= new EpisodeRepository(_context);
    public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);
    public IWatchHistoryRepository WatchHistory => _watchHistoryRepository ??= new WatchHistoryRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
} 