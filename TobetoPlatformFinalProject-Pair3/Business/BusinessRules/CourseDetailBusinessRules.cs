using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities;
using Entities.Concretes;

namespace Business.BusinessRules;

public class CourseDetailBusinessRules  : BaseBusinessRules
{
    ICourseDetailDal _courseDetailDal;

    public CourseDetailBusinessRules(ICourseDetailDal courseDetailDal)
    {
        _courseDetailDal = courseDetailDal;
    }


    public Task CourseDetailShouldExistWhenSelected(CourseDetail? courseDetail)
    {
        if (courseDetail == null)
            throw new BusinessException(CourseDetailMessages.CourseDetailNotExists);
        return Task.CompletedTask;
    }
}