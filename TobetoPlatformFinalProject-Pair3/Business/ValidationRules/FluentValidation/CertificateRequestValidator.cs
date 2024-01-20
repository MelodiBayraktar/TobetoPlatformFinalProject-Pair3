using Business.Dtos.Certificate.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CertificateRequestValidator : AbstractValidator<CreateCertificateRequest>
    {
        public CertificateRequestValidator()
        {
            // userdan filename okunacak
            // RuleFor(r => r.Name).NotEmpty().MinimumLength(2).WithMessage(Messages.MustContainAtMinTwoChar);
            // RuleFor(r => r.Folder).NotEmpty(); 
        }
    }

}
