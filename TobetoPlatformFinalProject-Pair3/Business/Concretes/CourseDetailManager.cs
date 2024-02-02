using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.CourseDetail.Requests;
using Business.Dtos.CourseDetail.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CourseDetailManager : ICourseDetailService
{
    private ICourseDetailDal _courseDetailDal;
    private IMapper _mapper;

    public CourseDetailManager(ICourseDetailDal courseDetailDal, IMapper mapper)
    {
        _courseDetailDal = courseDetailDal;
        _mapper = mapper;
    }
    [SecuredOperation("courseDetails.add,admin")]
    [ValidationAspect(typeof(CourseDetailRequestValidator))]
    public async Task<CreatedCourseDetailResponse> AddAsync(CreateCourseDetailRequest createCourseDetailRequest)
    {
        CourseDetail courseDetail = _mapper.Map<CourseDetail>(createCourseDetailRequest);
        Expression<Func<CourseDetail, object>> includeExpressionForCourseCategory = x => x.CourseCategory;
        var createCourseDetail = await _courseDetailDal.AddAsync(courseDetail, includeExpressionForCourseCategory);
        CreatedCourseDetailResponse response = _mapper.Map<CreatedCourseDetailResponse>(createCourseDetail);
        return response;
    }
    [SecuredOperation("courseDetails.delete,admin")]
    public async Task<DeletedCourseDetailResponse> DeleteAsync(DeleteCourseDetailRequest deleteCourseDetailRequest)
    {
        CourseDetail courseDetail = await _courseDetailDal.GetAsync(c => c.Id == deleteCourseDetailRequest.Id);
        await _courseDetailDal.DeleteAsync(courseDetail);
        DeletedCourseDetailResponse response = _mapper.Map<DeletedCourseDetailResponse>(courseDetail);
        return response;
    }

    public async Task<GetCourseDetailResponse> GetById(GetCourseDetailRequest getCourseDetailRequest)
    {
        CourseDetail getCourseDetail = await _courseDetailDal.GetAsync(c => c.Id == getCourseDetailRequest.Id,
            include: p => p.Include(p => p.CourseCategory));
        GetCourseDetailResponse response = _mapper.Map<GetCourseDetailResponse>(getCourseDetail);
        return response;
    }

    public async Task<IPaginate<GetListedCourseDetailResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseDetailDal.GetListAsync(include: p => p.Include(p => p.CourseCategory), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedCourseDetailResponse> response = _mapper.Map<Paginate<GetListedCourseDetailResponse>>(getList);
        return response;
    }
    [SecuredOperation("courseDetails.update,admin")]
    public async Task<UpdatedCourseDetailResponse> UpdateAsync(UpdateCourseDetailRequest updateCourseDetailRequest)
    {
        var result = await _courseDetailDal.GetAsync(predicate: a => a.Id == updateCourseDetailRequest.Id);
        _mapper.Map(updateCourseDetailRequest, result);
        await _courseDetailDal.UpdateAsync(result);
        UpdatedCourseDetailResponse response = _mapper.Map<UpdatedCourseDetailResponse>(result);
        return response;
    }
}