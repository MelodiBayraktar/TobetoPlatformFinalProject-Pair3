using Business.Constants;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Certificate.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AbilityRequestValidator : AbstractValidator<CreateAbilityRequest>
    {
        public AbilityRequestValidator()
        {
            RuleFor(r => r.Name).NotEmpty().MinimumLength(5);
        }
    }
}
