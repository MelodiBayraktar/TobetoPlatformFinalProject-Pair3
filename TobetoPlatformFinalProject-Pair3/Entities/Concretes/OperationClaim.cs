using Core.Entities.Abstracts;
using Core.Entities.Concretes;

namespace Entities.Concretes;
public class OperationClaim : Entity<Guid>, IOperationClaim
{
    public string? Name { get; set; }

    public List<UserOperationClaim>? UserOperationClaims { get; set; }
}
