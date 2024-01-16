namespace Business.Dtos.OperationClaim.Requests;

public class UpdateUserOperationClaimRequest
{
    public Guid? UserId { get; set; }
    public Guid? OperationClaimId { get; set; }
    public string? Name { get; set; }
}