using Core.Entities.Concretes;

namespace Entities.Concretes;

public class LiveContent : Entity<Guid>
{
    public Guid? LiveCourseId { get; set;}
    public string? Name { get; set; }
    public string? Type { get; set; }
    public bool? IsContinue { get; set; }

    public LiveCourse? LiveCourse { get; set; }
    public List<Session>? Sessions { get; set; }
}

