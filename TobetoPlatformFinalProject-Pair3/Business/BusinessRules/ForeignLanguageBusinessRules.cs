using Business.Constants;
using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities;

namespace Business.BusinessRules;

public class ForeignLanguageBusinessRules : BaseBusinessRules
{
    IForeignLanguageDal _foreignlanguageDal;

    public ForeignLanguageBusinessRules(IForeignLanguageDal foreignlanguageDal)
    {
        _foreignlanguageDal = foreignlanguageDal;
    }

    public Task ForeignLanguageShouldExistWhenSelected(ForeignLanguage? foreignlanguage)
    {
        if (foreignlanguage == null)
            throw new BusinessException(ForeignLanguageMessages.ForeignLanguageNotExists);
        return Task.CompletedTask;
    }
}