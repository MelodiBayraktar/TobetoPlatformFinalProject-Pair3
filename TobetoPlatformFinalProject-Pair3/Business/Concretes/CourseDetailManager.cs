using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseDetail.Requests;
using Business.Dtos.CourseDetail.Responses;
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

    public async Task<CreatedCourseDetailResponse> AddAsync(CreateCourseDetailRequest createCourseDetailRequest)
    {
        // var courseDetail = _mapper.Map<CourseDetail>(createCourseDetailRequest);
        // var createCourseDetail = await _courseDetailDal.AddAsync(courseDetail);
        // return _mapper.Map<CreatedCourseDetailResponse>(createCourseDetail);
        var courseDetail = _mapper.Map<CourseDetail>(createCourseDetailRequest);
        Expression<Func<CourseDetail, object>> includeExpressionForCourseCategory = x => x.CourseCategory;

        var createCourseDetail = await _courseDetailDal.AddAsync(courseDetail, includeExpressionForCourseCategory);
        return _mapper.Map<CreatedCourseDetailResponse>(createCourseDetail);
    }

    public async Task<DeletedCourseDetailResponse> DeleteAsync(DeleteCourseDetailRequest deleteCourseDetailRequest)
    {
        var courseDetail = await _courseDetailDal.GetAsync(c => c.Id == deleteCourseDetailRequest.Id);
        var deleteCourseDetail = await _courseDetailDal.DeleteAsync(courseDetail);
        return _mapper.Map<DeletedCourseDetailResponse>(deleteCourseDetail);
    }

    public async Task<GetCourseDetailResponse> GetById(GetCourseDetailRequest getCourseDetailRequest)
    {
        var getCourseDetail = await _courseDetailDal.GetAsync(c => c.Id == getCourseDetailRequest.Id);
        return _mapper.Map<GetCourseDetailResponse>(getCourseDetail);
    }

    public async Task<IPaginate<GetListedCourseDetailResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseDetailDal.GetListAsync(include: p => p.Include(p => p.CourseCategory), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedCourseDetailResponse>>(getList);
    }

    public async Task<UpdatedCourseDetailResponse> UpdateAsync(UpdateCourseDetailRequest updateCourseDetailRequest)
    {
        var courseDetail = _mapper.Map<CourseDetail>(updateCourseDetailRequest);
        var updatedCourseDetail = await _courseDetailDal.UpdateAsync(courseDetail);
        return _mapper.Map<UpdatedCourseDetailResponse>(updatedCourseDetail);
    }
}