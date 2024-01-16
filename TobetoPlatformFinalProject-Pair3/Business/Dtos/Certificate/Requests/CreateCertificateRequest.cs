namespace Business.Dtos.Certificate.Requests;

public class CreateCertificateRequest
{
    public Guid? UserId { get; set;}
    public string? FilePath { get; set; }
    public string? FileType { get; set; }
    public DateTime? UploadDate { get; set; }
}