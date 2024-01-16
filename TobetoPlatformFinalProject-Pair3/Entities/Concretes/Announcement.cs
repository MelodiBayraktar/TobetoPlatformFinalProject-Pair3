using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Announcement : Entity<Guid>
{
    public Guid? AnnouncementsNewsCategoryId { get; set; }
    public Guid? ProjectId { get; set; }
    public string? Title { get; set; }
    public string? AnnouncementContent { get; set; }
    public Project? Project { get; set; }
    public AnnouncementsNewsCategory? AnnouncementsNewsCategory { get; set;}
}