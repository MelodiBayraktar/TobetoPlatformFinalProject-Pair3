using Business.Dtos.AsyncLessonsOfContent.Requests;
using Business.Dtos.ContactUs.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactUsRequestValidator : AbstractValidator<CreateContactUsRequest>
    {
        public ContactUsRequestValidator()
        {

        }
    }
}
