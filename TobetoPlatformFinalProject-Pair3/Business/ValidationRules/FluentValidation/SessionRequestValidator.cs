using Business.Dtos.Project.Requests;
using Business.Dtos.Session.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SessionRequestValidator : AbstractValidator<CreateSessionRequest>
    {
        public SessionRequestValidator()
        {

        }
    }
}
