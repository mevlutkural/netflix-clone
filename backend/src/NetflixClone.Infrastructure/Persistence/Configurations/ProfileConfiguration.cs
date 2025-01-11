using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.AvatarUrl)
            .HasMaxLength(2000);

        builder.Property(p => p.Language)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(p => p.MaturityLevel)
            .HasMaxLength(20);

        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.HasMany(p => p.WatchHistory)
            .WithOne(w => w.Profile)
            .HasForeignKey(w => w.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 