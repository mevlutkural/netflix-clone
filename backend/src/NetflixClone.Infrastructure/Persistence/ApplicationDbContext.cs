using Microsoft.EntityFrameworkCore;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Series> Series => Set<Series>();
    public DbSet<Episode> Episodes => Set<Episode>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<WatchHistory> WatchHistories => Set<WatchHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
} 