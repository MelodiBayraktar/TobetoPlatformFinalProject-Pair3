using Business.Constants;
using Business.Dtos.SocialAccount.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SocialAccountRequestValidator : AbstractValidator<CreateSocialAccountRequest>{
        public SocialAccountRequestValidator() 
        {
            RuleFor(s => s.Name).MinimumLength(2).WithMessage(SocialAccountMessages.MustContainAtMinTwoChar);
            RuleFor(s => s.AccountUrl).NotEmpty();
    
        }
    }
    
}
