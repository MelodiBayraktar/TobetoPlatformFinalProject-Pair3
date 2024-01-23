using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class AsyncCourseBusinessRules  : BaseBusinessRules
{
    IAsyncCourseDal _asyncCourseDal;

    public AsyncCourseBusinessRules(IAsyncCourseDal asyncCourseDal)
    {
        _asyncCourseDal = asyncCourseDal;
    }


    public Task AsyncCourseShouldExistWhenSelected(AsyncCourse? asyncCourse)
    {
        if (asyncCourse == null)
            throw new BusinessException(AsyncCourseMessages.AsyncCourseNotExists);
        return Task.CompletedTask;
    }
}