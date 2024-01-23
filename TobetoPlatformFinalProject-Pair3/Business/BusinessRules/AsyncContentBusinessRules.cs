using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class AsyncContentBusinessRules : BaseBusinessRules
{
    IAsyncContentDal _asyncContentDal;

    public AsyncContentBusinessRules(IAsyncContentDal asyncContentDal)
    {
        _asyncContentDal = asyncContentDal;
    }


    public Task AsyncContentShouldExistWhenSelected(AsyncContent? asyncContent)
    {
        if (asyncContent == null)
            throw new BusinessException(AsyncContentMessages.AsyncContentNotExists);
        return Task.CompletedTask;
    }
}