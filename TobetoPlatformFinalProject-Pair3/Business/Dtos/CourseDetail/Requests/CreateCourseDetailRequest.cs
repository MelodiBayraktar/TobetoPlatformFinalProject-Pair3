namespace Business.Dtos.CourseDetail.Requests;

public class CreateCourseDetailRequest
{
    public Guid? CourseCategoryId { get; set; }
    public string? Name { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFavorited { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? SpentTime { get; set; }
    public int? ContentCount { get; set; }
}