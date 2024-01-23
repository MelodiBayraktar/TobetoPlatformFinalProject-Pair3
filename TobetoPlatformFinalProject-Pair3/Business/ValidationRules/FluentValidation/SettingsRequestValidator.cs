using Business.Dtos.Session.Requests;
using Business.Dtos.Settings.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SettingsRequestValidator : AbstractValidator<CreateSettingsRequest>
    {
        public SettingsRequestValidator()
        {

        }
    }
}
