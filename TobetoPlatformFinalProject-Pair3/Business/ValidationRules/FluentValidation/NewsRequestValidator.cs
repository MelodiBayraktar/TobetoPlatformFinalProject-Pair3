using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.News.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsRequestValidator : AbstractValidator<CreateNewsRequest>
    {
        public NewsRequestValidator()
        {

            RuleFor(p => p.Title).NotEmpty().MaximumLength(25);
            RuleFor(p => p.NewsContent).NotEmpty().MaximumLength(1500);
        }
    }
}
