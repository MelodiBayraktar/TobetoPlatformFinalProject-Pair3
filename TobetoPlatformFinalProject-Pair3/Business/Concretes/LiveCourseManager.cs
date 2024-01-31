using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.LiveCourse.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities;
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
        LiveCourse liveCourse = _mapper.Map<LiveCourse>(createLiveCourseRequest);
        Expression<Func<LiveCourse, object>> includeExpressionForCourse = x => x.Course;
        Expression<Func<LiveCourse, object>> includeExpressionForCourseDetail = y => y.CourseDetail;
        var createLiveCourse = await _liveCourseDal.AddAsync(liveCourse, includeExpressionForCourse,includeExpressionForCourseDetail);
        CreatedLiveCourseResponse response = _mapper.Map<CreatedLiveCourseResponse>(createLiveCourse);
        return response;
    }

    [SecuredOperation("liveCourses.delete,admin")]
    [CacheRemoveAspect("ILiveCourseService.Get")]
    public async Task<DeletedLiveCourseResponse> DeleteAsync(DeleteLiveCourseRequest deleteLiveCourseRequest)
    {
        LiveCourse liveCourse = await _liveCourseDal.GetAsync(c => c.Id == deleteLiveCourseRequest.Id);
        var deleteLiveCourse = await _liveCourseDal.DeleteAsync(liveCourse);
        DeletedLiveCourseResponse response = _mapper.Map<DeletedLiveCourseResponse>(deleteLiveCourse);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<GetLiveCourseResponse> GetById(GetLiveCourseRequest getLiveCourseRequest)
    {
        LiveCourse getLiveCourse = await _liveCourseDal.GetAsync(c => c.Id == getLiveCourseRequest.Id);
        GetLiveCourseResponse response = _mapper.Map<GetLiveCourseResponse>(getLiveCourse);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedLiveCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _liveCourseDal.GetListAsync(include: p => p.Include(p => p.CourseDetail).Include(p => p.Course), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedLiveCourseResponse> response = _mapper.Map<Paginate<GetListedLiveCourseResponse>>(getList);
        return response;
    }

    [SecuredOperation("liveCourses.update,admin")]
    [CacheRemoveAspect("ILiveCourseService.Get")]
    public async Task<UpdatedLiveCourseResponse> UpdateAsync(UpdateLiveCourseRequest updateLiveCourseRequest)
    {
        var result = await _liveCourseDal.GetAsync(predicate: a => a.Id == updateLiveCourseRequest.Id);
        _mapper.Map(updateLiveCourseRequest, result);
        await _liveCourseDal.UpdateAsync(result);
        UpdatedLiveCourseResponse response = _mapper.Map<UpdatedLiveCourseResponse>(result);
        return response;
    }
}