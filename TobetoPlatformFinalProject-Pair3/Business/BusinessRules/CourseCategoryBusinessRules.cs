using Business.Constants.Messages;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.BusinessRules;

public class CourseCategoryBusinessRules  : BaseBusinessRules
{
    ICourseCategoryDal _courseCategoryDal;

    public CourseCategoryBusinessRules(ICourseCategoryDal courseCategoryDal)
    {
        _courseCategoryDal = courseCategoryDal;
    }


    public Task CourseCategoryShouldExistWhenSelected(CourseCategory? courseCategory)
    {
        if (courseCategory == null)
            throw new BusinessException(CourseCategoryMessages.CourseCategoryNotExists);
        return Task.CompletedTask;
    }
}