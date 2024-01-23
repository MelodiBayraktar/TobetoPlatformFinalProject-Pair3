using Business.Dtos.AsyncCourse.Requests;
using Business.Dtos.AsyncLessonsDetail.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AsyncLessonsDetailRequestValidator : AbstractValidator<CreateAsyncLessonsDetailRequest>
    {
        public AsyncLessonsDetailRequestValidator()
        {

        }
    }
}
