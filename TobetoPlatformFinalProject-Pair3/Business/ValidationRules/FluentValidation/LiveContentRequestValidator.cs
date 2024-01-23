using Business.Dtos.Instructor.Requests;
using Business.Dtos.LiveContent.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LiveContentRequestValidator : AbstractValidator<CreateLiveContentRequest>
    {
        public LiveContentRequestValidator()
        {

        }
    }
}
