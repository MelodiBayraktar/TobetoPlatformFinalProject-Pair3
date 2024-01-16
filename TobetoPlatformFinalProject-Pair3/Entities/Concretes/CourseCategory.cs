using Core.Entities.Concretes;

namespace Entities.Concretes;

public class CourseCategory : Entity<Guid>
{
    public string? Name { get; set; }

    public List<CourseDetail>? CourseDetails { get; set; }
}
