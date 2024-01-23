using Business.Dtos.News.Requests;
using Business.Dtos.Project.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public ProjectRequestValidator()
        {

        }
    }
}
