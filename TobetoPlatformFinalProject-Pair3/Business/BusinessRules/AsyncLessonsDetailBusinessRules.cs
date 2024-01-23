using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class AsyncLessonsDetailBusinessRules  : BaseBusinessRules
{
    IAsyncLessonsDetailDal _asyncLessonsDetailDal;

    public AsyncLessonsDetailBusinessRules(IAsyncLessonsDetailDal asyncLessonsDetailDal)
    {
        _asyncLessonsDetailDal = asyncLessonsDetailDal;
    }


    public Task AsyncLessonsDetailShouldExistWhenSelected(AsyncLessonsDetail? asyncLessonsDetail)
    {
        if (asyncLessonsDetail == null)
            throw new BusinessException(AsyncLessonsDetailMessages.AsyncLessonsDetailNotExists);
        return Task.CompletedTask;
    }
}