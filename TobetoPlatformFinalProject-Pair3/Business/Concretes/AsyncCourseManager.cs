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
        AsyncCourse asyncCourse = _mapper.Map<AsyncCourse>(createAsyncCourseRequest);
        Expression<Func<AsyncCourse, object>> includeExpressionForCourseDetail = x => x.CourseDetail;
        Expression<Func<AsyncCourse, object>> includeExpressionForCourse = y => y.Course;
        var createAsyncCourse = await _asyncCourseDal.AddAsync(asyncCourse, includeExpressionForCourseDetail,includeExpressionForCourse);
        CreatedAsyncCourseResponse response = _mapper.Map<CreatedAsyncCourseResponse>(createAsyncCourse);
        return response;
        
    }
    [SecuredOperation("asyncCourses.delete,admin")]
    public async Task<DeletedAsyncCourseResponse> DeleteAsync(DeleteAsyncCourseRequest deleteAsyncCourseRequest)
    {
        AsyncCourse asyncCourse = await _asyncCourseDal.GetAsync(c => c.Id == deleteAsyncCourseRequest.Id); 
        await _asyncCourseDal.DeleteAsync(asyncCourse);
        DeletedAsyncCourseResponse response = _mapper.Map<DeletedAsyncCourseResponse>(asyncCourse);
        return response;
    }

    public async Task<GetAsyncCourseResponse> GetById(GetAsyncCourseRequest getAsyncCourseRequest)
    {
        AsyncCourse getAsyncCourse = await _asyncCourseDal.GetAsync(c => c.Id == getAsyncCourseRequest.Id);
        GetAsyncCourseResponse response = _mapper.Map<GetAsyncCourseResponse>(getAsyncCourse);
        return response;
    }

    public async Task<IPaginate<GetListedAsyncCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _asyncCourseDal.GetListAsync(include: p => p.Include(p => p.CourseDetail).Include(p => p.Course), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAsyncCourseResponse> response = _mapper.Map<Paginate<GetListedAsyncCourseResponse>>(getList);
        return response;
    }
    [SecuredOperation("asyncCourses.update,admin")]
    public async Task<UpdatedAsyncCourseResponse> UpdateAsync(UpdateAsyncCourseRequest updateAsyncCourseRequest)
    {
        var result = await _asyncCourseDal.GetAsync(predicate: a => a.Id == updateAsyncCourseRequest.Id);
        _mapper.Map(updateAsyncCourseRequest, result);
        await _asyncCourseDal.UpdateAsync(result);
        UpdatedAsyncCourseResponse response = _mapper.Map<UpdatedAsyncCourseResponse>(result);
        return response;
    }
}