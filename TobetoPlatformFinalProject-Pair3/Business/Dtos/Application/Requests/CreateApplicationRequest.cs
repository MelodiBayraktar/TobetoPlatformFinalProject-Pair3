namespace Business.Dtos.Application.Requests;

public class CreateApplicationRequest
{
    public Guid? ProjectId { get; set; }
    public string? Description { get; set; }
    public string? ApplicationForStatus { get; set; }
    public string? DocumentUploadForStatus { get; set; }
    public bool? ApplicationStatus { get; set; }
}