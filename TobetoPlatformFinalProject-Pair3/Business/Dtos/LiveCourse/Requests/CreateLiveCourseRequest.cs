namespace Business.Dtos.LiveCourse.Requests;

public class CreateLiveCourseRequest
{
    public Guid? CourseId { get; set;}
    public Guid? CourseDetailId { get; set; }
    public Guid? LiveCourseId { get; set; }

}