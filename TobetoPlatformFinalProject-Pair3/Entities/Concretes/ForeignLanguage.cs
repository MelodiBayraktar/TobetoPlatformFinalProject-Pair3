using Core.Entities;
using Core.Entities.Concretes;
using Entities.Concretes;

namespace Entities;

public class ForeignLanguage : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string LanguageLevel { get; set; }

    public User User { get; set; }
}
