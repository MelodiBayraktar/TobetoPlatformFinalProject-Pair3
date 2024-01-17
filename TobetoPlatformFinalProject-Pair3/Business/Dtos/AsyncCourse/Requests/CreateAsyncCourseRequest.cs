namespace Business.Dtos.AsyncCourse.Requests;

public class CreateAsyncCourseRequest
{
    public Guid? AsyncCourseId { get; set; }
    public Guid? CourseId { get; set; }
    public Guid? CourseDetailId { get; set; }
    public DateTime? EstimatedTime { get; set; }
    public string? ProducingCompany { get; set; }
}