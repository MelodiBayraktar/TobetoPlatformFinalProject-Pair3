using Core.Entities.Concretes;

namespace Entities.Concretes;

public class AnnouncementsNewsCategory : Entity<Guid>
{
    public string Name { get; set; }
    public List<Announcement> Announcements { get; set; }
    public List<News> News { get; set; }
}

