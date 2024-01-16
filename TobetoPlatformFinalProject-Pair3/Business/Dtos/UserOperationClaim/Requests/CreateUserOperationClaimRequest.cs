namespace Business.Dtos.OperationClaim.Requests;

public class CreateUserOperationClaimRequest
{
    public Guid? UserId { get; set; }
    public Guid? OperationClaimId { get; set; }
}