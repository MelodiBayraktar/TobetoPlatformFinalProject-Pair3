using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsOfContent.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AsyncLessonsOfContentRequestValidator : AbstractValidator<CreateAsyncLessonsOfContentRequest>
    {
        public AsyncLessonsOfContentRequestValidator()
        {

        }
    }
}
