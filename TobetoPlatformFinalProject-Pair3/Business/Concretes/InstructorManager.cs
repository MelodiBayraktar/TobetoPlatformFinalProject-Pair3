using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
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

public class InstructorManager : IInstructorService
{
    private IInstructorDal _instructorDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;

    public InstructorManager(IInstructorDal instructorDal, IMapper mapper, IGetUserId getUserId)
    {
        _instructorDal = instructorDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }

    [SecuredOperation("instructors.add,admin")]
    [ValidationAspect(typeof(InstructorRequestValidator))]
    public async Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest)
    {
        Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        instructor.UserId = userId;
        Expression<Func<Instructor, object>> includeExpressionForUser = x => x.User;
        var createInstructor = await _instructorDal.AddAsync(instructor, includeExpressionForUser);
        CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(createInstructor);
        return response;
    }

    [SecuredOperation("instructors.delete,admin")]
    public async Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest)
    {
        Instructor instructor = await _instructorDal.GetAsync(c => c.Id == deleteInstructorRequest.Id);
        var deleteInstructor = await _instructorDal.DeleteAsync(instructor);
        DeletedInstructorResponse response = _mapper.Map<DeletedInstructorResponse>(deleteInstructor);
        return response;
    }

    public async Task<GetInstructorResponse> GetById(GetInstructorRequest getInstructorRequest)
    {
        Instructor getInstructor = await _instructorDal.GetAsync(c => c.Id == getInstructorRequest.Id,
            include: p => p.Include(p => p.User));
        GetInstructorResponse response = _mapper.Map<GetInstructorResponse>(getInstructor);
        return response;
    }

    public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _instructorDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedInstructorResponse> response = _mapper.Map<Paginate<GetListedInstructorResponse>>(getList);
        return response;
    }

    [SecuredOperation("instructors.update,admin")]
    public async Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest)
    {
        var result = await _instructorDal.GetAsync(predicate: a => a.Id == updateInstructorRequest.Id);
        _mapper.Map(updateInstructorRequest, result);
        await _instructorDal.UpdateAsync(result);
        UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(result);
        return response;
    }
}