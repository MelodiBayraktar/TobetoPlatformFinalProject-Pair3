using Core.Entities.Concretes;

namespace Entities.Concretes;

public class AsyncCourse : Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid CourseDetailId { get; set; }
    public DateTime EstimatedTime { get; set; }
    public string ProducingCompany { get; set; }

    public Course Course { get; set; }
    public List<AsyncContent> AsyncContents { get; set; }
    public List<AsyncLessonsOfContent> AsyncLessonsOfContents { get; set; }
    public CourseDetail CourseDetail { get; set; }
}