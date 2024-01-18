namespace Business.Dtos.Experience.Responses;

public class GetListedExperienceResponse
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    public string? OrganizationName { get; set; }
    public string? Position { get; set; }
    public string? Sector { get; set; }
    public string? City { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
}
