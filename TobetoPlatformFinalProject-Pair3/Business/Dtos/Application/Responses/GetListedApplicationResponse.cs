namespace Business.Dtos.Application.Responses;
public class GetListedApplicationResponse
{
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? ApplicationForStatus { get; set; }
    public string? DocumentUploadForStatus { get; set; }
    public bool? ApplicationStatus { get; set; }
}
