namespace Business.Dtos.AsyncCourse.Responses;

public class GetListedAsyncCourseResponse
{
    public Guid? Id { get; set; }
    public Guid? CourseId { get; set; }
    public string? CourseDetailName { get; set; }
    public DateTime? EstimatedTime { get; set; }
    public string? ProducingCompany { get; set; }
}