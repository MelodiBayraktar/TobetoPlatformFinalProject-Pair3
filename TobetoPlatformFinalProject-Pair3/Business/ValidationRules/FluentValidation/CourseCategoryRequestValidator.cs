using Business.Dtos.ContactUs.Requests;
using Business.Dtos.CourseCategory.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseCategoryRequestValidator : AbstractValidator<CreateCourseCategoryRequest>
    {
        public CourseCategoryRequestValidator()
        {

        }
    }
}
