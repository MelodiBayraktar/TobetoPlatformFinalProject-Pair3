using Core.Entities.Concretes;

namespace Entities.Concretes;

public class News : Entity<Guid>
{
    public Guid? AnnouncementsNewsCategoryId { get; set; }
    public Guid? ProjectId { get; set; }
    public string? Title { get; set; }
    public string? NewsContent { get; set; }
    public Project? Project { get; set; }
    public AnnouncementsNewsCategory? AnnouncementsNewsCategory { get; set; }
}