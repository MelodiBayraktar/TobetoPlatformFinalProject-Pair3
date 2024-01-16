namespace Business.Dtos.PasswordReset.Requests;

public class CreatePasswordResetRequest
{
    public Guid? UserId { get; set; }
    public string? VerificationCode { get; set; }
    public bool? IsUsed { get; set; }
}