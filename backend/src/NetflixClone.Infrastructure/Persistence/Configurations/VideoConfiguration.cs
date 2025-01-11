using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(v => v.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(v => v.ThumbnailUrl)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(v => v.VideoUrl)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(v => v.Director)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(v => v.Cast)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(v => v.Languages)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        builder.Property(v => v.Subtitles)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        builder.Property(v => v.VideoQualities)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        builder.HasQueryFilter(v => !v.IsDeleted);

        builder.HasMany(v => v.Categories)
            .WithMany();

        builder.HasMany(v => v.WatchHistory)
            .WithOne(w => w.Video)
            .HasForeignKey(w => w.VideoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 