using Core.Entities.Concretes;

namespace Entities.Concretes;

public class ContactUs : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Message { get; set; }
}

