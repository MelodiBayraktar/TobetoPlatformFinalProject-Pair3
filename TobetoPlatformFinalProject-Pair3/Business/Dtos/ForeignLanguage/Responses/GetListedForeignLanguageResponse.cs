namespace Business.Dtos.ForeignLanguage.Responses;

public class GetListedForeignLanguageResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LanguageLevel { get; set; }
}
