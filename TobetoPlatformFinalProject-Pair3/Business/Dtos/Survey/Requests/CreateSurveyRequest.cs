namespace Business.Dtos.Survey.Requests;

public class CreateSurveyRequest
{
    public Guid StudentId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}