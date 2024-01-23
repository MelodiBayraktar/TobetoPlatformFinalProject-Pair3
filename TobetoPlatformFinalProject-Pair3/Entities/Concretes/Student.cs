using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Student : Entity<Guid>
{
    public Guid UserId { get; set; }

    public User User { get; set; }
    public List<Survey> Surveys { get; set; }
    public List<CourseExam> CourseExams { get; set; }
}
