using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Course.Responses;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationManager : IEducationService
{
    private IEducationDal _educationDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;
    public EducationManager(IEducationDal educationDal, IMapper mapper, IGetUserId getUserId)
    {
        _educationDal = educationDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }
    [SecuredOperation("educations.add,admin,mod")]
    [ValidationAspect(typeof(EducationRequestValidator))]
    public async Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest)
    {
        Education education = _mapper.Map<Education>(createEducationRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        education.UserId = userId;
        Expression<Func<Education, object>> includeExpressionForUser = x => x.User;
        var createEducation = await _educationDal.AddAsync(education, includeExpressionForUser);
        CreatedEducationResponse response = _mapper.Map<CreatedEducationResponse>(createEducation);
        return response;
    }

    public async Task<DeletedEducationResponse> DeleteAsync(DeleteEducationRequest deleteEducationRequest)
    {
        Education education = await _educationDal.GetAsync(c => c.Id == deleteEducationRequest.Id);
        var deleteEducation = await _educationDal.DeleteAsync(education);
        DeletedEducationResponse response =  _mapper.Map<DeletedEducationResponse>(deleteEducation);
        return response;
    }

    public async Task<GetEducationResponse> GetById(GetEducationRequest getEducationRequest)
    {
        Education getEducation = await _educationDal.GetAsync(c => c.Id == getEducationRequest.Id,
            include: p => p.Include(p => p.User));
        GetEducationResponse response =  _mapper.Map<GetEducationResponse>(getEducation);
        return response;
    }

    public async Task<IPaginate<GetListedEducationResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _educationDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedEducationResponse> response = _mapper.Map<Paginate<GetListedEducationResponse>>(getList);
        return response;
    }

    public async Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest)
    {
        var result = await _educationDal.GetAsync(predicate: a => a.Id == updateEducationRequest.Id);
        _mapper.Map(updateEducationRequest, result);
        await _educationDal.UpdateAsync(result);
        UpdatedEducationResponse response = _mapper.Map<UpdatedEducationResponse>(result);
        return response;
    }
}