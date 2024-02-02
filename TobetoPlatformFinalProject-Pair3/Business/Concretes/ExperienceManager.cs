using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Education.Responses;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
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

public class ExperienceManager : IExperienceService
{
    private IExperienceDal _experienceDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;

    public ExperienceManager(IExperienceDal experienceDal, IMapper mapper, IGetUserId getUserId)
    {
        _experienceDal = experienceDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }
    [SecuredOperation("experiences.add,admin,mod")]
    [ValidationAspect(typeof(ExperienceRequestValidator))]
    public async Task<CreatedExperienceResponse> AddAsync(CreateExperienceRequest createExperienceRequest)
    {
        Experience experience = _mapper.Map<Experience>(createExperienceRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        experience.UserId = userId;
        Expression<Func<Experience, object>> includeExpressionForUser = x => x.User;
        var createExperience = await _experienceDal.AddAsync(experience, includeExpressionForUser);
        CreatedExperienceResponse response = _mapper.Map<CreatedExperienceResponse>(createExperience);
        return response;
    }

    public async Task<DeletedExperienceResponse> DeleteAsync(DeleteExperienceRequest deleteExperienceRequest)
    {
        Experience experience = await _experienceDal.GetAsync(c => c.Id == deleteExperienceRequest.Id);
        var deleteExperience = await _experienceDal.DeleteAsync(experience);
        DeletedExperienceResponse response =  _mapper.Map<DeletedExperienceResponse>(deleteExperience);
        return response;
    }

    public async Task<GetExperienceResponse> GetById(GetExperienceRequest getExperienceRequest)
    {
        Experience getExperience = await _experienceDal.GetAsync(c => c.Id == getExperienceRequest.Id,
            include: p => p.Include(p => p.User));
        GetExperienceResponse response = _mapper.Map<GetExperienceResponse>(getExperience);
        return response;
    }

    public async Task<IPaginate<GetListedExperienceResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _experienceDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedExperienceResponse> response = _mapper.Map<Paginate<GetListedExperienceResponse>>(getList);
        return response;
    }

    public async Task<UpdatedExperienceResponse> UpdateAsync(UpdateExperienceRequest updateExperienceRequest)
    {
        var result = await _experienceDal.GetAsync(predicate: a => a.Id == updateExperienceRequest.Id);
        _mapper.Map(updateExperienceRequest, result);
        await _experienceDal.UpdateAsync(result);
        UpdatedExperienceResponse response = _mapper.Map<UpdatedExperienceResponse>(result);
        return response;
    }
}