using Microsoft.EntityFrameworkCore;
using NetflixClone.Application.Interfaces;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Repositories;

public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Profile>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.WatchHistory)
            .Where(p => p.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetProfileCountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(p => p.UserId == userId, cancellationToken);
    }

    public override async Task<Profile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.WatchHistory)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
} 