using Core.Entities.Concretes;

namespace Entities.Concretes;

public class AsyncLessonsOfContent : Entity<Guid>
{
    public Guid AsyncContentId { get; set; }
    public Guid AsyncCourseId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Duration { get; set; }
    public bool IsCompleted { get; set; }
    public string ImageUrl { get; set; }
    public string VideoUrl { get; set; }

    public AsyncContent AsyncContent { get; set; }
    public AsyncCourse AsyncCourse { get; set; }
    public List<AsyncLessonsDetail> AsyncLessonsDetails { get; set; }

}