namespace Business.Dtos.Instructor.Requests;

public class CreateInstructorRequest
{
    public Guid? UserId { get; set;}
    public Guid? InstructorId { get; set;}
}