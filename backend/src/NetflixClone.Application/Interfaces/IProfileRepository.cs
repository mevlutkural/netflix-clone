using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Interfaces;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<IEnumerable<Profile>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<int> GetProfileCountByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
} 