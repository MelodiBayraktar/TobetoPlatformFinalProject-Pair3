using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.Student.Requests;
using Business.Dtos.Student.Responses;
using Business.ValidationRules.FluentValidation;
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

public class StudentManager : IStudentService
{
    private IStudentDal _studentDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;

    public StudentManager(IStudentDal studentDal, IMapper mapper, IGetUserId getUserId)
    {
        _studentDal = studentDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }

    [SecuredOperation("students.add,admin")]
    [ValidationAspect(typeof(StudentRequestValidator))]
    public async Task<CreatedStudentResponse> AddAsync(CreateStudentRequest createStudentRequest)
    {
        Student student = _mapper.Map<Student>(createStudentRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        student.UserId = userId;
        Expression<Func<Student, object>> includeExpressionForUser = x => x.User;
        var createStudent = await _studentDal.AddAsync(student, includeExpressionForUser);
        CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(createStudent);
        return response;
    }

    [SecuredOperation("students.delete,admin")]
    public async Task<DeletedStudentResponse> DeleteAsync(DeleteStudentRequest deleteStudentRequest)
    {
        Student student = await _studentDal.GetAsync(c => c.Id == deleteStudentRequest.Id);
        var deleteStudent = await _studentDal.DeleteAsync(student);
        DeletedStudentResponse response = _mapper.Map<DeletedStudentResponse>(deleteStudent);
        return response;
    }

    public async Task<GetStudentResponse> GetById(GetStudentRequest getStudentRequest)
    {
        Student getStudent = await _studentDal.GetAsync(c => c.Id == getStudentRequest.Id,
            include: p => p.Include(p => p.User));
        GetStudentResponse response = _mapper.Map<GetStudentResponse>(getStudent);
        return response;
    }

    public async Task<IPaginate<GetListedStudentResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _studentDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedStudentResponse> response = _mapper.Map<Paginate<GetListedStudentResponse>>(getList);
        return response;
    }


    [SecuredOperation("students.update,admin")]
    public async Task<UpdatedStudentResponse> UpdateAsync(UpdateStudentRequest updateStudentRequest)
    {
        var result = await _studentDal.GetAsync(predicate: a => a.Id == updateStudentRequest.Id);
        _mapper.Map(updateStudentRequest, result);
        await _studentDal.UpdateAsync(result);
        UpdatedStudentResponse response = _mapper.Map<UpdatedStudentResponse>(result);
        return response;
    }
}