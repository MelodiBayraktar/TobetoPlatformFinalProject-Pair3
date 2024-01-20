using Business.Constants;
using Business.Dtos.Experience.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ExperienceRequestValidator : AbstractValidator<CreateExperienceRequest>
    {
        public ExperienceRequestValidator()
        {
            RuleFor(r => r.City).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.OrganizationName).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.Sector).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.Position).NotEmpty().MinimumLength(5).MaximumLength(50).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.Description).MaximumLength(300).WithMessage("En fazla 300 karakter olmalı");
            RuleFor(r => r.StartDate).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.EndDate).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);

         
        }
    }
}
