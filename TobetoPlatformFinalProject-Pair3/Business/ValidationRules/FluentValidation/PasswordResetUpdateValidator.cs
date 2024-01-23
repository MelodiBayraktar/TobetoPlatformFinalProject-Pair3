using Business.Constants;
using Business.Dtos.PasswordReset.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PasswordResetUpdateValidator : AbstractValidator<UpdatePasswordResetRequest>
    {
        public PasswordResetUpdateValidator()
        {
            RuleFor(r => r.Email).MinimumLength(5).NotEmpty().EmailAddress();
            
        }
    }
}
