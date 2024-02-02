using Core.Entities.Concretes;

namespace Business.Dtos.CourseExam.Requests;

public class CreateCourseExamRequest
{
    public Guid StudentId { get; set; }
    public Guid CourseDetailId { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
    public string ExamUrl { get; set; }
}