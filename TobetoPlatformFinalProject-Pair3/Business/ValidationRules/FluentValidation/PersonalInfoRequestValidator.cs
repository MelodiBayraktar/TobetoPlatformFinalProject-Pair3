using Business.Constants;
using Business.Dtos.PersonalInfo.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonalInfoRequestValidator : AbstractValidator<CreatePersonalInfoRequest>
    {
        public PersonalInfoRequestValidator()
        {
            RuleFor(r => r.City).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.Country).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.NationalIdentity).NotEmpty().MaximumLength(11).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.BirthDate).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.Address).NotEmpty().MaximumLength(200).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.District).NotEmpty().MaximumLength(200).WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.About).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);
            RuleFor(r => r.ProfileImageUrl).NotEmpty().WithMessage(UserMessages.MustContainAtMinTwoChar);

            //firstname , lastname ,img
            
            //RuleFor(r => r.PasswordSalt).NotEmpty()
            //    .WithMessage(UserMessages.MustContainAtMinTwoChar).WithMessage(UserMessages.MustContainAtMaxTenChar);
        }
    }
}
