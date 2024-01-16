namespace Business.Dtos.OperationClaim.Responses;

public class GetListedUserOperationClaimResponse
{
    public Guid? UserId { get; set; }
    public Guid? OperationClaimId { get; set; }
    public string? Name { get; set; }
}