namespace Business.Dtos.OperationClaim.Responses;

public class GetUserOperationClaimResponse
{
    public Guid? UserId { get; set; }
    public Guid? OperationClaimId { get; set; }
    public string? Name { get; set; }
}