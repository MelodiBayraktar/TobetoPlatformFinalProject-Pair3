using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.AnnouncementsNewsCategory.Requests;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnouncementsNewsCategoryRequestValidator : AbstractValidator<CreateAnnouncementsNewsCategoryRequest>
    {
        public AnnouncementsNewsCategoryRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
