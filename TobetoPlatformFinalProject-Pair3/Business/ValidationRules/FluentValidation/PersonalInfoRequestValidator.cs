using Business.Constants;
using Business.Constants.Messages;
using Business.Dtos.PersonalInfo.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonalInfoRequestValidator : AbstractValidator<CreatePersonalInfoRequest>
    {
        public PersonalInfoRequestValidator()
        {
            RuleFor(r => r.City).NotEmpty().WithMessage(PersonalInfoMessages.RequiredField);
            RuleFor(r => r.Country).NotEmpty().WithMessage(PersonalInfoMessages.RequiredField);
            RuleFor(r => r.NationalIdentity).NotEmpty().MaximumLength(11).MinimumLength(11).WithMessage(PersonalInfoMessages.RequiredField).WithMessage(PersonalInfoMessages.Min11Number).WithMessage(PersonalInfoMessages.Max11Number);
            RuleFor(r => r.BirthDate).NotEmpty().WithMessage(PersonalInfoMessages.RequiredField);
            RuleFor(r => r.Address).NotEmpty().MaximumLength(200).WithMessage(PersonalInfoMessages.RequiredField).WithMessage(PersonalInfoMessages.Max200Char);
            RuleFor(r => r.District).NotEmpty().MaximumLength(200).WithMessage(PersonalInfoMessages.RequiredField).WithMessage(PersonalInfoMessages.Max200Char);
            RuleFor(r => r.About).NotEmpty().WithMessage(PersonalInfoMessages.RequiredField);
            RuleFor(r => r.ProfileImageUrl).NotEmpty().WithMessage(PersonalInfoMessages.RequiredField);

            //firstname , lastname ,img
            
            //RuleFor(r => r.PasswordSalt).NotEmpty()
            //    .WithMessage(UserMessages.MustContainAtMinTwoChar).WithMessage(UserMessages.MustContainAtMaxTenChar);
        }
    }
}
