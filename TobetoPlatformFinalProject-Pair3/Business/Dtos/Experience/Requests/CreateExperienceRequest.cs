namespace Business.Dtos.Experience.Requests;

public class CreateExperienceRequest
{
    public Guid? UserId { get; set; }
    public string? OrganizationName { get; set; }
    public string? Position { get; set; }
    public string? Sector { get; set; }
    public string? City { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
}