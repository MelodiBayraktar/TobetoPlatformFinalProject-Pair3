using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using Entities.Concretes;

namespace Business.BusinessRules;

public class AbilityBusinessRules : BaseBusinessRules
{
    public Task AbilityShouldExistWhenSelected(Ability? ability)
    {
        if (ability == null)
            throw new BusinessException(AbilityMessages.AbilityNotExists);
        return Task.CompletedTask;
    }
}