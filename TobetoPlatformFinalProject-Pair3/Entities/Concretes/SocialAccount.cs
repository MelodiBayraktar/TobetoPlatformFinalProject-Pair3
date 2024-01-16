using Core.Entities.Concretes;

namespace Entities.Concretes;

public class SocialAccount : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? AccountUrl { get; set; }

    public User? User { get; set; }
}
