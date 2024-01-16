using Core.Entities.Concretes;

namespace Entities.Concretes;

public class AsyncContent : Entity<Guid>
{
    public Guid? AsyncCourseId { get; set; }
    public string? Name { get; set; }
    public AsyncCourse? AsyncCourse { get; set; }
    public List<AsyncLessonsOfContent>? AsyncLessonsOfContents { get; set; }
}
