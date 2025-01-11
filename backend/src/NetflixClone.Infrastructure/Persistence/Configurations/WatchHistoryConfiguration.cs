using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class WatchHistoryConfiguration : IEntityTypeConfiguration<WatchHistory>
{
    public void Configure(EntityTypeBuilder<WatchHistory> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasQueryFilter(w => !w.IsDeleted);

        builder.HasIndex(w => new { w.ProfileId, w.VideoId })
            .IsUnique();
    }
} 