using Business.Constants;
using Business.Dtos.PasswordReset.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PasswordResetRequestValidator : AbstractValidator<CreatePasswordResetRequest>
    {
        public PasswordResetRequestValidator()
        {
            //RuleFor(r => r.Password).MinimumLength(8).MaximumLength(10).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar).WithMessage(UserMessages.MustContainAtMaxTenChar);
            
        }
    }
}
