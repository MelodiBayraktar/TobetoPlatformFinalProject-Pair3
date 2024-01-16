using Core.Entities.Abstracts;
using Core.Entities.Concretes;

namespace Entities.Concretes;
public class UserOperationClaim : Entity<Guid>, IUserOperationClaim
{
    public Guid? UserId { get; set; }
    public Guid? OperationClaimId { get; set; }


    public User? User { get; set; }
    public OperationClaim? OperationClaim { get; set; }
}
