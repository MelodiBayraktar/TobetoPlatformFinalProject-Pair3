namespace Business.Dtos.Session.Requests;

public class CreateSessionRequest
{
    public Guid InstructorId { get; set; }
    public Guid LiveContentId { get; set; }
    public string Name { get; set; }    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RecordUrl { get; set; }
    public string SessionLinkUrl { get; set; }
}