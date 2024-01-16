namespace Business.Dtos.AsyncLessonsOfContent.Requests;

public class CreateAsyncLessonsOfContentRequest
{
    public Guid? AsyncContentId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int? Duration { get; set; }
    public bool? IsCompleted { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
}