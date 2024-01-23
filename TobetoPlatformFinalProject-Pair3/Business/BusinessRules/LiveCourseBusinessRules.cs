using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class LiveCourseBusinessRules  : BaseBusinessRules
{
    ILiveCourseDal _liveCourseDal;

    public LiveCourseBusinessRules(ILiveCourseDal liveCourseDal)
    {
        _liveCourseDal = liveCourseDal;
    }

    public Task CheckIfExamNotExist(LiveCourse liveCourse)
    {
        if (liveCourse == null) 
            throw new BusinessException(LiveCourseMessages.LiveCourseNotExist);
        return Task.CompletedTask;

    }
}