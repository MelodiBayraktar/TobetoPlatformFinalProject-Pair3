using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Application : Entity<Guid>
{
    public Guid ProjectId { get; set; }
    
    public string Description { get; set; }
    public string ApplicationForStatus { get; set; }
    public string DocumentUploadForStatus { get; set; }
    public bool ApplicationStatus { get; set; }

    public Project Project { get; set; }
}
