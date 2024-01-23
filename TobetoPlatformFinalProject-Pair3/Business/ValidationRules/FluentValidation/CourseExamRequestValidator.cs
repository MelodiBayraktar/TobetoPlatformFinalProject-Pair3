using Business.Dtos.CourseDetail.Requests;
using Business.Dtos.CourseExam.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseExamRequestValidator : AbstractValidator<CreateCourseExamRequest>
    {
        public CourseExamRequestValidator()
        {

        }
    }
}
