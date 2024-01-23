using Business.Dtos.CourseCategory.Requests;
using Business.Dtos.CourseDetail.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseDetailRequestValidator : AbstractValidator<CreateCourseDetailRequest>
    {
        public CourseDetailRequestValidator()
        {

        }
    }
}
