namespace Business.Dtos.Course.Requests;

public class CreateCourseRequest
{
    public Guid UserId { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
}