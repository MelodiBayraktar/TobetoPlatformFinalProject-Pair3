using Business.Constants;
using Business.Dtos.ForeignLanguage.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ForeignLanguageRequestValidator : AbstractValidator<CreateForeignLanguageRequest>
    {
        public ForeignLanguageRequestValidator()
        {
             RuleFor(r => r.Name).NotEmpty().WithMessage(ForeignLanguageMessages.InputCanNotBeEmpty);
             RuleFor(r => r.LanguageLevel).NotEmpty().WithMessage(ForeignLanguageMessages.InputCanNotBeEmpty);
        }
    }
}
