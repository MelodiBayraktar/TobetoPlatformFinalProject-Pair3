using Business.Constants;
using Business.Dtos.PasswordReset.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PasswordResetRequestValidator : AbstractValidator<UpdatePasswordResetRequest>
    {
        public PasswordResetRequestValidator()
        {
            RuleFor(r => r.Email).MinimumLength(5).NotEmpty().EmailAddress();
            
        }
    }
}
