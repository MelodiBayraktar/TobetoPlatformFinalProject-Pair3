namespace Business.Dtos.Certificate.Requests;

public class CreateCertificateRequest
{
    public string FilePath { get; set; }
    public string FileType { get; set; }
    public DateTime UploadDate { get; set; }
}