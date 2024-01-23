using Business.Dtos.Course.Requests;
using Business.Dtos.CourseExam.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseRequestValidator : AbstractValidator<CreateCourseRequest>
    {
        public CourseRequestValidator()
        {

        }
    }
}
