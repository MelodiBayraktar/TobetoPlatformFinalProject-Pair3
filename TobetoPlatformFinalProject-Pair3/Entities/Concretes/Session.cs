using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Session : Entity<Guid>
{
    public Guid? InstructorId { get; set; }
    public Guid? LiveContentId { get; set; }
    public string? Name { get; set; }    
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? RecordUrl { get; set; }
    public string? SessionLinkUrl { get; set; }

    public LiveContent? LiveContent { get; set; }
    public Instructor? Instructor { get; set; }
}
