using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Application.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ApplicationRequestValidator : AbstractValidator<CreateApplicationRequest>
    {
        public ApplicationRequestValidator()
        {
            RuleFor(p => p.Description).NotEmpty().MaximumLength(25);
        }
    }
}
