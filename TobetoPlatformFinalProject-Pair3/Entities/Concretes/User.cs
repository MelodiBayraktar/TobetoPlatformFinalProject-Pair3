using Core.Entities.Abstracts;
using Core.Entities.Concretes;

namespace Entities.Concretes;

public class User : Entity<Guid>, IUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public List<Ability> Abilities { get; set; }
    public List<ForeignLanguage> ForeignLanguages { get; set; }
    public List<Education> Educations { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<SocialAccount> SocialAccounts { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<PersonalInfo> PersonalInfos { get; set; }
    public List<PasswordReset> PasswordResets { get; set; }
    public List<Settings> Settings { get; set; }
    public List<Instructor> Instructors { get; set; }
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }
    public List<UserOperationClaim> UserOperationClaims { get; set; }

}
