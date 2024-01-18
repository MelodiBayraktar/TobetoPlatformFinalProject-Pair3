namespace Business.Dtos.Course.Requests;

public class CreateCourseRequest
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public string? ImageUrl { get; set; }
    public string? Title { get; set; }
}