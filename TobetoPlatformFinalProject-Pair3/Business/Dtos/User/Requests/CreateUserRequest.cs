namespace Business.Dtos.User.Requests;

public class CreateUserRequest
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    //public string Password { get; set; }
    public bool Status { get; set; }
}