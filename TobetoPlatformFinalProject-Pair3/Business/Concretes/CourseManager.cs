using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Certificate.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CourseManager : ICourseService
{
    private ICourseDal _courseDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;
    public CourseManager(ICourseDal courseDal, IMapper mapper, IGetUserId getUserId)
    {
        _courseDal = courseDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }
    [SecuredOperation("courses.add,admin")]
    [ValidationAspect(typeof(CourseRequestValidator))]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest)
    {
        Course course = _mapper.Map<Course>(createCourseRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        course.UserId = userId;
        Expression<Func<Course, object>> includeExpressionForUser = x => x.User;
        var createCourse = await _courseDal.AddAsync(course, includeExpressionForUser);
        CreatedCourseResponse response = _mapper.Map<CreatedCourseResponse>(createCourse);
        return response;
    }

    [SecuredOperation("courses.delete,admin")]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest)
    {
        Course course = await _courseDal.GetAsync(c => c.Id == deleteCourseRequest.Id);
        var deleteCourse = await _courseDal.DeleteAsync(course);
        DeletedCourseResponse response = _mapper.Map<DeletedCourseResponse>(deleteCourse);
        return response;
    }

    [CacheAspect(duration:10)]
    public async Task<GetCourseResponse> GetById(GetCourseRequest getCourseRequest)
    {
        Course getCourse = await _courseDal.GetAsync(c => c.Id == getCourseRequest.Id,
            include: p => p.Include(p => p.User));
        GetCourseResponse response = _mapper.Map<GetCourseResponse>(getCourse);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedCourseResponse> response =  _mapper.Map<Paginate<GetListedCourseResponse>>(getList);
        return response;
    }

    [SecuredOperation("courses.update,admin")]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest)
    {
        var result = await _courseDal.GetAsync(predicate: a => a.Id == updateCourseRequest.Id);
        _mapper.Map(updateCourseRequest, result);
        await _courseDal.UpdateAsync(result);
        UpdatedCourseResponse response = _mapper.Map<UpdatedCourseResponse>(result);
        return response;
    }
}