using Business.Dtos.Education.Requests;
using Business.Dtos.Instructor.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class InstructorRequestValidator : AbstractValidator<CreateInstructorRequest>
    {
        public InstructorRequestValidator()
        {

        }
    }
}
