namespace Business.Dtos.OperationClaim.Responses;

public class GetUserOperationClaimResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}