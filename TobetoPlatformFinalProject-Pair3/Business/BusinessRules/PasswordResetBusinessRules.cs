using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class PasswordResetBusinessRules :BaseBusinessRules
{
    IPasswordResetDal _passwordResetDal;

    public PasswordResetBusinessRules (IPasswordResetDal passwordResetDal)
    {
        _passwordResetDal = passwordResetDal;
    }

    public Task PasswordResetMustExistWhenSelected(PasswordReset passwordReset)
    {
        if (passwordReset == null)
            throw new BusinessException(PasswordResetMessages.PasswordResetNotExists);
        return Task.CompletedTask;
    }
}