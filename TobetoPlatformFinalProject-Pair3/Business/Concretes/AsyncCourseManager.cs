using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.AsyncCourse.Requests;
using Business.Dtos.AsyncCourse.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AsyncCourseManager : IAsyncCourseService
{
    private IAsyncCourseDal _asyncCourseDal;
    private IMapper _mapper;

    public AsyncCourseManager(IAsyncCourseDal asyncCourseDal, IMapper mapper)
    {
        _asyncCourseDal = asyncCourseDal;
        _mapper = mapper;
    }
    [SecuredOperation("asyncCourses.add,admin")]
    [ValidationAspect(typeof(AsyncCourseRequestValidator))]
    public async Task<CreatedAsyncCourseResponse> AddAsync(CreateAsyncCourseRequest createAsyncCourseRequest)
    {
        // var asyncCourse = _mapper.Map<AsyncCourse>(createAsyncCourseRequest);
        // var createAsyncCourse = await _asyncCourseDal.AddAsync(asyncCourse);
        // return _mapper.Map<CreatedAsyncCourseResponse>(createAsyncCourse);
        var asyncCourse = _mapper.Map<AsyncCourse>(createAsyncCourseRequest);
        Expression<Func<AsyncCourse, object>> includeExpressionForCourseDetail = x => x.CourseDetail;
        Expression<Func<AsyncCourse, object>> includeExpressionForCourse = y => y.Course;
        
        var createAsyncCourse = await _asyncCourseDal.AddAsync(asyncCourse, includeExpressionForCourseDetail,includeExpressionForCourse);
        return _mapper.Map<CreatedAsyncCourseResponse>(createAsyncCourse);    
    }
    [SecuredOperation("asyncCourses.delete,admin")]
    public async Task<DeletedAsyncCourseResponse> DeleteAsync(DeleteAsyncCourseRequest deleteAsyncCourseRequest)
    {
        var asyncCourse = await _asyncCourseDal.GetAsync(c => c.Id == deleteAsyncCourseRequest.Id);
        var deleteAsyncCourse = await _asyncCourseDal.DeleteAsync(asyncCourse);
        return _mapper.Map<DeletedAsyncCourseResponse>(deleteAsyncCourse);
    }

    public async Task<GetAsyncCourseResponse> GetById(GetAsyncCourseRequest getAsyncCourseRequest)
    {
        var getAsyncCourse = await _asyncCourseDal.GetAsync(c => c.Id == getAsyncCourseRequest.Id);
        return _mapper.Map<GetAsyncCourseResponse>(getAsyncCourse);
    }

    public async Task<IPaginate<GetListedAsyncCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncCourseDal.GetListAsync(include: p => p.Include(p => p.CourseDetail).Include(p => p.Course), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedAsyncCourseResponse>>(getList);
    }
    [SecuredOperation("asyncCourses.update,admin")]
    public async Task<UpdatedAsyncCourseResponse> UpdateAsync(UpdateAsyncCourseRequest updateAsyncCourseRequest)
    {
        var asyncCourse = _mapper.Map<AsyncCourse>(updateAsyncCourseRequest);
        var updatedAsyncCourse = await _asyncCourseDal.UpdateAsync(asyncCourse);
        return _mapper.Map<UpdatedAsyncCourseResponse>(updatedAsyncCourse);
    }
}