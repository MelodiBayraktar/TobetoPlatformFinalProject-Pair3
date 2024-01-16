using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Course : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? ImageUrl { get; set; }
    public string? Title { get; set; }

    public User? User { get; set; }
    public List<AsyncCourse>? AsyncCourses { get; set; }
    public List<LiveCourse>? LiveCourses { get; set; }
}