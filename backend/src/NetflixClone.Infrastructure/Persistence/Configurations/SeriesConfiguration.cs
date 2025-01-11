using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(s => s.ThumbnailUrl)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(s => s.TrailerUrl)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(s => s.Creator)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Cast)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasQueryFilter(s => !s.IsDeleted);

        builder.HasMany(s => s.Episodes)
            .WithOne(e => e.Series)
            .HasForeignKey(e => e.SeriesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Categories)
            .WithMany();
    }
} 