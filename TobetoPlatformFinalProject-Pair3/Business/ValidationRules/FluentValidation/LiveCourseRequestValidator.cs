using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveCourse.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LiveCourseRequestValidator : AbstractValidator<CreateLiveCourseRequest>
    {
        public LiveCourseRequestValidator()
        {

        }
    }
}
