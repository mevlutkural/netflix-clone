using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(m => m.TrailerUrl)
            .HasMaxLength(2000)
            .IsRequired();
    }
} 