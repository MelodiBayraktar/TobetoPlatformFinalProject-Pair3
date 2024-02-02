using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Responses;
using Business.Dtos.Experience.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
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

public class PersonalInfoManager : IPersonalInfoService
{
    private IPersonalInfoDal _personalInfoDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;
    private PersonalInfoBusinessRules _personalInfoBusinessRules;

    public PersonalInfoManager(IPersonalInfoDal personalInfoDal, IMapper mapper, IGetUserId getUserId,PersonalInfoBusinessRules personalInfoBusinessRules)
    {
        _personalInfoDal = personalInfoDal;
        _mapper = mapper;
        _getUserId = getUserId;
        _personalInfoBusinessRules = personalInfoBusinessRules;
    }

    [SecuredOperation("personalInfos.add,admin,mod")]
    [ValidationAspect(typeof(PersonalInfoRequestValidator))]
    public async Task<CreatedPersonalInfoResponse> AddAsync(CreatePersonalInfoRequest createPersonalInfoRequest)
    {
        PersonalInfo personalInfo = _mapper.Map<PersonalInfo>(createPersonalInfoRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        personalInfo.UserId = userId;
        await _personalInfoBusinessRules.PersonalInformationShouldExistWhenSelected(personalInfo);
        Expression<Func<PersonalInfo, object>> includeExpressionForUser = x => x.User;
        var createPersonalInfo = await _personalInfoDal.AddAsync(personalInfo, includeExpressionForUser);
        CreatedPersonalInfoResponse response = _mapper.Map<CreatedPersonalInfoResponse>(createPersonalInfo);
        return response;

    }
   
    public async Task<DeletedPersonalInfoResponse> DeleteAsync(DeletePersonalInfoRequest deletePersonalInfoRequest)
    {
        PersonalInfo personalInfo = await _personalInfoDal.GetAsync(c => c.Id == deletePersonalInfoRequest.Id);
        var deletePersonalInfo = await _personalInfoDal.DeleteAsync(personalInfo);
        DeletedPersonalInfoResponse response = _mapper.Map<DeletedPersonalInfoResponse>(deletePersonalInfo);
        return response;
    }

    public async Task<GetPersonalInfoResponse> GetById(GetPersonalInfoRequest getPersonalInfoRequest)
    {
        PersonalInfo getPersonalInfo = await _personalInfoDal.GetAsync(c => c.Id == getPersonalInfoRequest.Id,
            include: p => p.Include(p => p.User));
        GetPersonalInfoResponse response = _mapper.Map<GetPersonalInfoResponse>(getPersonalInfo);
        return response;
    }

    public async Task<IPaginate<GetListedPersonalInfoResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _personalInfoDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedPersonalInfoResponse> response = _mapper.Map<Paginate<GetListedPersonalInfoResponse>>(getList);
        return response;
    }

    public async Task<UpdatedPersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest updatePersonalInfoRequest)
    {
        var result = await _personalInfoDal.GetAsync(predicate: a => a.Id == updatePersonalInfoRequest.Id);
        _mapper.Map(updatePersonalInfoRequest, result);
        await _personalInfoDal.UpdateAsync(result);
        UpdatedPersonalInfoResponse response = _mapper.Map<UpdatedPersonalInfoResponse>(result);
        return response;
    }
}