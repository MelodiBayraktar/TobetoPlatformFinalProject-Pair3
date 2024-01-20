using Business.Constants;
using Business.Constants.Messages;
using Business.Dtos.Experience.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ExperienceRequestValidator : AbstractValidator<CreateExperienceRequest>
    {
        public ExperienceRequestValidator()
        {
            RuleFor(r => r.City).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);
            RuleFor(r => r.OrganizationName).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);
            RuleFor(r => r.Sector).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);
            RuleFor(r => r.Position).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);
            RuleFor(r => r.Description).MaximumLength(300).WithMessage(ExperienceMessages.MustContainAtMax300Char);
            RuleFor(r => r.StartDate).NotEmpty().WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);
            RuleFor(r => r.EndDate).NotEmpty().WithMessage(ExperienceMessages.MustContainAtMin5Char).WithMessage(ExperienceMessages.MustContainAtMax50Char);

         
        }
    }
}
