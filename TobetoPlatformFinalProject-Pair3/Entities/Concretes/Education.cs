using Core.Entities;
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Entities;

public class Education : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? EducationLevel { get; set; }
    public string? University { get; set; }
    public string? Department { get; set; }
    public DateTime? StartDate { get; set; }
    public int? GraduationYear { get; set; }

    public User? User { get; set; }
}