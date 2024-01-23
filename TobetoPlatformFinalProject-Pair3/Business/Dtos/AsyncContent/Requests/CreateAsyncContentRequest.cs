namespace Business.Dtos.AsyncContent.Requests;

public class CreateAsyncContentRequest
{
    public Guid AsyncCourseId { get; set; }
    public string Name { get; set; }
}