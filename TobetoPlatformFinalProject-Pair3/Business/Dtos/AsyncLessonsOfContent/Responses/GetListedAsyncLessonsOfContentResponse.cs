namespace Business.Dtos.AsyncLessonsOfContent.Responses;

public class GetListedAsyncLessonsOfContentResponse
{
    public Guid Id { get; set; }
    public Guid AsyncContentId { get; set; }
    public Guid AsyncCourseId { get; set; }
    public string AsyncContentName { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Duration { get; set; }
    public bool IsCompleted { get; set; }
    public string ImageUrl { get; set; }
    public string VideoUrl { get; set; }
}
