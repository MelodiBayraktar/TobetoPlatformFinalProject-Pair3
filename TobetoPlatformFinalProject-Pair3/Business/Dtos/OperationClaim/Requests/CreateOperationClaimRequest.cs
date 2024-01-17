namespace Business.Dtos.OperationClaim.Requests;

public class CreateOperationClaimRequest
{
    public Guid? OperationClaimId { get; set; }
    public string? Name { get; set; }
}