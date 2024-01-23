using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Project : Entity<Guid>
{
    public string Name { get; set; }

    public List<Application> Applications { get; set; }
    public List<News> News { get; set; }
    public List<Announcement> Announcements { get; set; } 
}
