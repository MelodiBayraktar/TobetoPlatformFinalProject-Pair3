using Core.Entities.Concretes;

namespace Entities.Concretes;

public class PasswordReset : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? VerificationCode { get; set; }
    public User? User { get; set; }
}
