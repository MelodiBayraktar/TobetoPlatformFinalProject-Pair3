using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class AsyncLessonsOfContentBusinessRules  : BaseBusinessRules
{
    IAsyncLessonsOfContentDal _asyncLessonsOfContentDal;

    public AsyncLessonsOfContentBusinessRules(IAsyncLessonsOfContentDal asyncLessonsOfContentDal)
    {
        _asyncLessonsOfContentDal = asyncLessonsOfContentDal;
    }


    public Task AsyncLessonsOfContentShouldExistWhenSelected(AsyncLessonsOfContent? asyncLessonsOfContent)
    {
        if (asyncLessonsOfContent == null)
            throw new BusinessException(AsyncLessonsOfContentMessages.AsyncLessonsOfContentNotExists);
        return Task.CompletedTask;
    }
}