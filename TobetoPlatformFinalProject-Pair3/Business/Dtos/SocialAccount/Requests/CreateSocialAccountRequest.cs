namespace Business.Dtos.SocialAccount.Requests;

public class CreateSocialAccountRequest
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string AccountUrl { get; set; }
}