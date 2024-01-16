using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Survey : Entity<Guid>
{
    public Guid? StudentId { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }

    public Student? Student { get; set; }
}
