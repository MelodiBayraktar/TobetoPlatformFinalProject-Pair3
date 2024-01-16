namespace Business.Dtos.ContactUs.Requests;

public class CreateContactUsRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Message { get; set; }
}