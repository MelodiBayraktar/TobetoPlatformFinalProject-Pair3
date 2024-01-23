namespace Business.Dtos.ForeignLanguage.Requests;

public class CreateForeignLanguageRequest
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string LanguageLevel { get; set; }
}