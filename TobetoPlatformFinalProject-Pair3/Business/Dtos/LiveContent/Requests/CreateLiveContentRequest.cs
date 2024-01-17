namespace Business.Dtos.LiveContent.Requests;

public class CreateLiveContentRequest
{
    public Guid? LiveCourseId { get; set;}
    public Guid? LiveContentId { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public bool? IsContinue { get; set; }
}