namespace Business.Dtos.OperationClaim.Responses;

public class GetListedUserOperationClaimResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}