using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.CourseCategory.Requests;
using Business.Dtos.CourseCategory.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CourseCategoryManager : ICourseCategoryService
{
    private ICourseCategoryDal _courseCategoryDal;
    private IMapper _mapper;

    public CourseCategoryManager(ICourseCategoryDal courseCategoryDal, IMapper mapper)
    {
        _courseCategoryDal = courseCategoryDal;
        _mapper = mapper;
    }
    [SecuredOperation("courseCategories.add,admin")]
    [ValidationAspect(typeof(CourseCategoryRequestValidator))]
    public async Task<CreatedCourseCategoryResponse> AddAsync(CreateCourseCategoryRequest createCourseCategoryRequest)
    {
        var courseCategory = _mapper.Map<CourseCategory>(createCourseCategoryRequest);
        var createCourseCategory = await _courseCategoryDal.AddAsync(courseCategory);
        return _mapper.Map<CreatedCourseCategoryResponse>(createCourseCategory);
    }
    [SecuredOperation("courseCategories.delete,admin")]
    public async Task<DeletedCourseCategoryResponse> DeleteAsync(DeleteCourseCategoryRequest deleteCourseCategoryRequest)
    {
        var courseCategory = await _courseCategoryDal.GetAsync(c => c.Id == deleteCourseCategoryRequest.Id);
        var deleteCourseCategory = await _courseCategoryDal.DeleteAsync(courseCategory);
        return _mapper.Map<DeletedCourseCategoryResponse>(deleteCourseCategory);
    }

    public async Task<GetCourseCategoryResponse> GetById(GetCourseCategoryRequest getCourseCategoryRequest)
    {
        var getCourseCategory = await _courseCategoryDal.GetAsync(c => c.Id == getCourseCategoryRequest.Id);
        return _mapper.Map<GetCourseCategoryResponse>(getCourseCategory);
    }

    public async Task<IPaginate<GetListedCourseCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseCategoryDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedCourseCategoryResponse>>(getList);
    }
    [SecuredOperation("courseCategories.update,admin")]
    public async Task<UpdatedCourseCategoryResponse> UpdateAsync(UpdateCourseCategoryRequest updateCourseCategoryRequest)
    {
        var courseCategory = _mapper.Map<CourseCategory>(updateCourseCategoryRequest);
        var updatedCourseCategory = await _courseCategoryDal.UpdateAsync(courseCategory);
        return _mapper.Map<UpdatedCourseCategoryResponse>(updatedCourseCategory);
    }
}