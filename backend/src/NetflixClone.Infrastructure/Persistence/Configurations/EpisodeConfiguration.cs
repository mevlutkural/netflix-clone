using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.HasIndex(e => new { e.SeriesId, e.SeasonNumber, e.EpisodeNumber })
            .IsUnique();
    }
} 