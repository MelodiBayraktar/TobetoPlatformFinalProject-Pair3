namespace Business.Dtos.Education.Responses;
public class GetListedEducationResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string EducationLevel { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public int GraduationYear { get; set; }
}
