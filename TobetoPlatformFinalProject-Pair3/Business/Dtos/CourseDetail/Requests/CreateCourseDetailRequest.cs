namespace Business.Dtos.CourseDetail.Requests;

public class CreateCourseDetailRequest
{
    public Guid CourseCategoryId { get; set; }
    public Guid CourseDetailId { get; set; }
    public string Name { get; set; }
    public bool IsLiked { get; set; }
    public bool IsFavorited { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int SpentTime { get; set; }
    public int ContentCount { get; set; }
}