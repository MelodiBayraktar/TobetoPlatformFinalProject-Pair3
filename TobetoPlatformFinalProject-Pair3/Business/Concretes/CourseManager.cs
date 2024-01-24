using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Certificate.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CourseManager : ICourseService
{
    private ICourseDal _courseDal;
    private IMapper _mapper;

    public CourseManager(ICourseDal courseDal, IMapper mapper)
    {
        _courseDal = courseDal;
        _mapper = mapper;
    }
    [SecuredOperation("courses.add,admin")]
    [ValidationAspect(typeof(CourseRequestValidator))]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest)
    {
        // var course = _mapper.Map<Course>(createCourseRequest);
        // var createCourse = await _courseDal.AddAsync(course);
        // return _mapper.Map<CreatedCourseResponse>(createCourse);
        var course = _mapper.Map<Course>(createCourseRequest);
        Expression<Func<Course, object>> includeExpressionForUser = x => x.User;

        var createCourse = await _courseDal.AddAsync(course, includeExpressionForUser);
        return _mapper.Map<CreatedCourseResponse>(createCourse);
    }

    [SecuredOperation("courses.delete,admin")]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest)
    {
        var course = await _courseDal.GetAsync(c => c.Id == deleteCourseRequest.Id);
        var deleteCourse = await _courseDal.DeleteAsync(course);
        return _mapper.Map<DeletedCourseResponse>(deleteCourse);
    }

    [CacheAspect(duration:10)]
    public async Task<GetCourseResponse> GetById(GetCourseRequest getCourseRequest)
    {
        var getCourse = await _courseDal.GetAsync(c => c.Id == getCourseRequest.Id);
        return _mapper.Map<GetCourseResponse>(getCourse);
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedCourseResponse>>(getList);
    }

    [SecuredOperation("courses.update,admin")]
    [CacheRemoveAspect("ICourseService.Get")]
    public async Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest)
    {
        var course = _mapper.Map<Course>(updateCourseRequest);
        var updatedCourse = await _courseDal.UpdateAsync(course);
        return _mapper.Map<UpdatedCourseResponse>(updatedCourse);
    }
}