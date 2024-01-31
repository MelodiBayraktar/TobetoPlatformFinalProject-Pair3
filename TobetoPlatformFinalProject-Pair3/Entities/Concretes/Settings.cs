using Core.Entities.Concretes;

namespace Entities.Concretes;

public class Settings : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

    public User User { get; set; }
}
