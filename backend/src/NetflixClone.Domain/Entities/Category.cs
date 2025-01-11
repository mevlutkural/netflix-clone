using NetflixClone.Domain.Common;

namespace NetflixClone.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ThumbnailUrl { get; private set; }
    public virtual ICollection<Movie> Movies { get; private set; }
    public virtual ICollection<Series> Series { get; private set; }

    private Category() : base()
    {
        Movies = new List<Movie>();
        Series = new List<Series>();
    }

    public Category(string name, string description, string thumbnailUrl) : this()
    {
        Name = name;
        Description = description;
        ThumbnailUrl = thumbnailUrl;
    }

    public void Update(string name, string description, string thumbnailUrl)
    {
        Name = name;
        Description = description;
        ThumbnailUrl = thumbnailUrl;
        base.Update();
    }
} 