namespace Business.Dtos.OperationClaim.Requests;

public class UpdateUserOperationClaimRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}