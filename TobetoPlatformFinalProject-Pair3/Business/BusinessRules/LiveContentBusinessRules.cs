using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities;
using Entities.Concretes;

namespace Business.BusinessRules;

public class LiveContentBusinessRules  : BaseBusinessRules
{
    ILiveContentDal _liveContentDal;

    public LiveContentBusinessRules(ILiveContentDal liveContentDal)
    {
        _liveContentDal = liveContentDal;
    }

    public Task CheckIfExamNotExist(LiveContent liveContent)
    {
        if (liveContent == null) 
            throw new BusinessException(LiveContentMessages.LiveContentNotExist);
        return Task.CompletedTask;

    }
}