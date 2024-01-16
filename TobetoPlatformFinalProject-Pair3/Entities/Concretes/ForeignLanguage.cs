using Core.Entities;

namespace Entities;

public class ForeignLanguage : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? LanguageLevel { get; set; }

    public User? User { get; set; }
}
