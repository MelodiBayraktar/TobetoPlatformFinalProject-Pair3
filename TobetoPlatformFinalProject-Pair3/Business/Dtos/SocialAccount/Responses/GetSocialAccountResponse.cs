namespace Business.Dtos.SocialAccount.Responses;

public class GetSocialAccountResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string AccountUrl { get; set; }
}
