using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class SessionBusinessRules  : BaseBusinessRules
{
    ISessionDal _sessionDal;

    public SessionBusinessRules(ISessionDal sessionDal)
    {
        _sessionDal = sessionDal;
    }

    public Task SessionShouldExistWhenSelected(Session session)
    {
        if (session == null)
            throw new BusinessException(SessionMessages.SessionNotExists);
        return Task.CompletedTask;
    }
}