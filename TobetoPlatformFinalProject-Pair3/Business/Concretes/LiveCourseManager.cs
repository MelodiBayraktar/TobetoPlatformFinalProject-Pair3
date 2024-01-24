using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.LiveCourse.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class LiveCourseManager : ILiveCourseService
{
    private ILiveCourseDal _liveCourseDal;
    private IMapper _mapper;

    public LiveCourseManager(ILiveCourseDal liveCourseDal, IMapper mapper)
    {
        _liveCourseDal = liveCourseDal;
        _mapper = mapper;
    }

    [SecuredOperation("liveCourses.add,admin")]
    [ValidationAspect(typeof(LiveCourseRequestValidator))]
    [CacheRemoveAspect("ILiveCourseService.Get")]
    public async Task<CreatedLiveCourseResponse> AddAsync(CreateLiveCourseRequest createLiveCourseRequest)
    {
        // var liveCourse = _mapper.Map<LiveCourse>(createLiveCourseRequest);
        // var createLiveCourse = await _liveCourseDal.AddAsync(liveCourse);
        // return _mapper.Map<CreatedLiveCourseResponse>(createLiveCourse);
        var liveCourse = _mapper.Map<LiveCourse>(createLiveCourseRequest);
        Expression<Func<LiveCourse, object>> includeExpressionForCourse = x => x.Course;
        Expression<Func<LiveCourse, object>> includeExpressionForCourseDetail = y => y.CourseDetail;
        
        var createLiveCourse = await _liveCourseDal.AddAsync(liveCourse, includeExpressionForCourse,includeExpressionForCourseDetail);
        return _mapper.Map<CreatedLiveCourseResponse>(createLiveCourse);
    }

    [SecuredOperation("liveCourses.delete,admin")]
    [CacheRemoveAspect("ILiveCourseService.Get")]
    public async Task<DeletedLiveCourseResponse> DeleteAsync(DeleteLiveCourseRequest deleteLiveCourseRequest)
    {
        var liveCourse = await _liveCourseDal.GetAsync(c => c.Id == deleteLiveCourseRequest.Id);
        var deleteLiveCourse = await _liveCourseDal.DeleteAsync(liveCourse);
        return _mapper.Map<DeletedLiveCourseResponse>(deleteLiveCourse);
    }

    [CacheAspect(duration: 10)]
    public async Task<GetLiveCourseResponse> GetById(GetLiveCourseRequest getLiveCourseRequest)
    {
        var getLiveCourse = await _liveCourseDal.GetAsync(c => c.Id == getLiveCourseRequest.Id);
        return _mapper.Map<GetLiveCourseResponse>(getLiveCourse);
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedLiveCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _liveCourseDal.GetListAsync(include: p => p.Include(p => p.CourseDetail).Include(p => p.Course), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedLiveCourseResponse>>(getList);
    }

    [SecuredOperation("liveCourses.update,admin")]
    [CacheRemoveAspect("ILiveCourseService.Get")]
    public async Task<UpdatedLiveCourseResponse> UpdateAsync(UpdateLiveCourseRequest updateLiveCourseRequest)
    {
        var liveCourse = _mapper.Map<LiveCourse>(updateLiveCourseRequest);
        var updatedLiveCourse = await _liveCourseDal.UpdateAsync(liveCourse);
        return _mapper.Map<UpdatedLiveCourseResponse>(updatedLiveCourse);
    }
}