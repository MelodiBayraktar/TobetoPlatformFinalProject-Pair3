using Core.Entities;
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Entities;

public class CourseDetail : Entity<Guid>
{
    public Guid? CourseCategoryId { get; set; }
    public string? Name { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFavorited { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? SpentTime { get; set; }
    public int? ContentCount { get; set; }

    public List<LiveCourse>? LiveCourses { get; set; }
    public List<AsyncCourse>? AsyncCourses { get; set; }

    public CourseCategory? CourseCategory { get; set; }
}