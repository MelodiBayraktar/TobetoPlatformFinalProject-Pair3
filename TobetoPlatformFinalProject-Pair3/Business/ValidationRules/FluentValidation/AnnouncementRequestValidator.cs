using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Announcement.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnouncementRequestValidator : AbstractValidator<CreateAnnouncementRequest>
    {
        public AnnouncementRequestValidator()
        {
            RuleFor(p => p.Title).NotEmpty().MaximumLength(25);
            RuleFor(p => p.AnnouncementContent).NotEmpty().MaximumLength(1500);
        }
    }
}
