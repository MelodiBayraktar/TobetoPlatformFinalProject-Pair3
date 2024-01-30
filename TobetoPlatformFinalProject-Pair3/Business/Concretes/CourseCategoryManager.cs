using System.Linq.Expressions;
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
        CourseCategory courseCategory = _mapper.Map<CourseCategory>(createCourseCategoryRequest);
        var createCourseCategory = await _courseCategoryDal.AddAsync(courseCategory);
        return _mapper.Map<CreatedCourseCategoryResponse>(createCourseCategory);
    }
    [SecuredOperation("courseCategories.delete,admin")]
    public async Task<DeletedCourseCategoryResponse> DeleteAsync(DeleteCourseCategoryRequest deleteCourseCategoryRequest)
    {
        CourseCategory courseCategory = await _courseCategoryDal.GetAsync(c => c.Id == deleteCourseCategoryRequest.Id); 
        await _courseCategoryDal.DeleteAsync(courseCategory);
        DeletedCourseCategoryResponse response =  _mapper.Map<DeletedCourseCategoryResponse>(courseCategory);
        return response;
    }

    public async Task<GetCourseCategoryResponse> GetById(GetCourseCategoryRequest getCourseCategoryRequest)
    {
        CourseCategory getCourseCategory = await _courseCategoryDal.GetAsync(c => c.Id == getCourseCategoryRequest.Id);
        GetCourseCategoryResponse response = _mapper.Map<GetCourseCategoryResponse>(getCourseCategory);
        return response;
    }

    public async Task<IPaginate<GetListedCourseCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseCategoryDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedCourseCategoryResponse> response =  _mapper.Map<Paginate<GetListedCourseCategoryResponse>>(getList);
        return response;
    }
    [SecuredOperation("courseCategories.update,admin")]
    public async Task<UpdatedCourseCategoryResponse> UpdateAsync(UpdateCourseCategoryRequest updateCourseCategoryRequest)
    {
        var result = await _courseCategoryDal.GetAsync(predicate: a => a.Id == updateCourseCategoryRequest.Id);
        _mapper.Map(updateCourseCategoryRequest, result);
        await _courseCategoryDal.UpdateAsync(result);
        UpdatedCourseCategoryResponse response = _mapper.Map<UpdatedCourseCategoryResponse>(result);
        return response;
    }
}