using Business.Constants;
using Business.Dtos.Auth.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class AuthLoginRequestValidator: AbstractValidator<AuthForLoginRequest>
{
    public AuthLoginRequestValidator()
    {
        RuleFor(r => r.Email).NotEmpty().EmailAddress();
        RuleFor(r => r.Password).MinimumLength(8).MaximumLength(10).NotEmpty()
            .WithMessage(UserMessages.MustContainAtMinTwoChar).WithMessage(UserMessages.MustContainAtMaxTenChar);
       
    }
}