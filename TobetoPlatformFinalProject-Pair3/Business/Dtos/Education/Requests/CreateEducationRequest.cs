namespace Business.Dtos.Education.Requests;

public class CreateEducationRequest
{
    public string EducationLevel { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public int GraduationYear { get; set; }
}