using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.AsyncCourse.Responses;
using Business.Dtos.CourseExam.Requests;
using Business.Dtos.CourseExam.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CourseExamManager : ICourseExamService
{
    private ICourseExamDal _courseExamDal;
    private IMapper _mapper;

    public CourseExamManager(ICourseExamDal courseExamDal, IMapper mapper)
    {
        _courseExamDal = courseExamDal;
        _mapper = mapper;
    }
    [SecuredOperation("courseExams.add,admin")]
    [ValidationAspect(typeof(CourseExamRequestValidator))]
    public async Task<CreatedCourseExamResponse> AddAsync(CreateCourseExamRequest createCourseExamRequest)
    {
        CourseExam courseExam = _mapper.Map<CourseExam>(createCourseExamRequest);
        Expression<Func<CourseExam, object>> includeExpressionForStudent = x => x.Student;
        var createCourseExam = await _courseExamDal.AddAsync(courseExam, includeExpressionForStudent);
        CreatedCourseExamResponse response = _mapper.Map<CreatedCourseExamResponse>(createCourseExam);
        return response;
    }
    [SecuredOperation("courseExams.delete,admin")]
    public async Task<DeletedCourseExamResponse> DeleteAsync(DeleteCourseExamRequest deleteCourseExamRequest)
    {
        CourseExam courseExam = await _courseExamDal.GetAsync(c => c.Id == deleteCourseExamRequest.Id);
        var deleteCourseExam = await _courseExamDal.DeleteAsync(courseExam);
        DeletedCourseExamResponse response = _mapper.Map<DeletedCourseExamResponse>(deleteCourseExam);
        return response;
    }

    public async Task<GetCourseExamResponse> GetById(GetCourseExamRequest getCourseExamRequest)
    {
        CourseExam getCourseExam = await _courseExamDal.GetAsync(c => c.Id == getCourseExamRequest.Id,
            include: p => p.Include(p => p.Student).Include(p => p.CourseDetail));
        GetCourseExamResponse response = _mapper.Map<GetCourseExamResponse>(getCourseExam);
        return response;
    }

    public async Task<IPaginate<GetListedCourseExamResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _courseExamDal.GetListAsync(include: p => p.Include(p => p.Student).Include(p=> p.CourseDetail),index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedCourseExamResponse> response = _mapper.Map<Paginate<GetListedCourseExamResponse>>(getList);
        return response;
  
    }
    [SecuredOperation("courseExams.update,admin")]
    public async Task<UpdatedCourseExamResponse> UpdateAsync(UpdateCourseExamRequest updateCourseExamRequest)
    {
        var result = await _courseExamDal.GetAsync(predicate: a => a.Id == updateCourseExamRequest.Id);
        _mapper.Map(updateCourseExamRequest, result);
        await _courseExamDal.UpdateAsync(result);
        UpdatedCourseExamResponse response = _mapper.Map<UpdatedCourseExamResponse>(result);
        return response;
    }
}