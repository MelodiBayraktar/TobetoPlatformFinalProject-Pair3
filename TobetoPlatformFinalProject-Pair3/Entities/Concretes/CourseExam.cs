using Core.Entities;
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Entities;

public class CourseExam : Entity<Guid>
{
    public Guid? StudentId { get; set; }
    public string? Name { get; set; }
    public string? Time { get; set; }
    public bool? Status { get; set; }
    public string? Description { get; set; }
    public string? ExamUrl { get; set; }

    public Student? Student { get; set; }
}
