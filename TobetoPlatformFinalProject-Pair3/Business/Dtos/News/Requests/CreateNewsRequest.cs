namespace Business.Dtos.News.Requests;

public class CreateNewsRequest
{
    public Guid? AnnouncementsNewsCategoryId { get; set; }
    public Guid? ProjectId { get; set; }
    public string? Title { get; set; }
    public string? NewsContent { get; set; }
}