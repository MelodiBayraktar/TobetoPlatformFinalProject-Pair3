using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class SettingsBusinessRules  : BaseBusinessRules
{
    ISettingsDal _settingsDal;

    public SettingsBusinessRules(ISettingsDal settingsDal)
    {
        _settingsDal = settingsDal;
    }

    public Task SettingsShouldExistWhenSelected(Settings settings)
    {
        if (settings == null)
            throw new BusinessException(SettingsMessages.SettingsNotExists);
        return Task.CompletedTask;
    }
}