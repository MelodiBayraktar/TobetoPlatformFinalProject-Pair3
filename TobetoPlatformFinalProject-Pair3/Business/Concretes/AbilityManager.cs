using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Business.Dtos.ContactUs.Requests;
using Business.Dtos.ContactUs.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Extensions;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using Core.Utilities.IoC;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Business.Concretes;

public class AbilityManager : IAbilityService
{
    private IAbilityDal _abilityDal;
    private IMapper _mapper;
    private AbilityBusinessRules _abilityBusinessRules;
    private IGetUserId _getUserId;


    public AbilityManager(IAbilityDal abilityDal, IMapper mapper, AbilityBusinessRules abilityBusinessRules, IGetUserId getUserId)
    {
        _abilityDal = abilityDal;
        _mapper = mapper;
        _abilityBusinessRules = abilityBusinessRules;
        _getUserId = getUserId;
    }

    //[SecuredOperation("abilities.add,admin,mod")]
    [ValidationAspect(typeof(AbilityRequestValidator))]
    [CacheRemoveAspect("IAbilityService.Get")]
    public async Task<CreatedAbilityResponse> AddAsync(CreateAbilityRequest createAbilityRequest)
    {
        Ability ability = _mapper.Map<Ability>(createAbilityRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        ability.UserId = userId;
        await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);
        Expression<Func<Ability, object>> includeExpressionForUser = x => x.User;
        var createAbility = await _abilityDal.AddAsync(ability, includeExpressionForUser);
        CreatedAbilityResponse response = _mapper.Map<CreatedAbilityResponse>(createAbility);
        return response;
    }

    [CacheRemoveAspect("IAbilityService.Get")]
    public async Task<DeletedAbilityResponse> DeleteAsync(DeleteAbilityRequest deleteAbilityRequest)
    {
        Ability ability = await _abilityDal.GetAsync(predicate: a => a.Id == deleteAbilityRequest.Id);
        await _abilityDal.DeleteAsync(ability);
        DeletedAbilityResponse response = _mapper.Map<DeletedAbilityResponse>(ability);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<GetAbilityResponse> GetById(GetAbilityRequest getAbilityRequest)
    {
        Ability getAbility = await _abilityDal.GetAsync(predicate: c => c.Id == getAbilityRequest.Id);
        GetAbilityResponse response = _mapper.Map<GetAbilityResponse>(getAbility);
        return response;
    }

    [CacheAspect(duration: 10)]
    public async Task<IPaginate<GetListedAbilityResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _abilityDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedAbilityResponse> response = _mapper.Map<Paginate<GetListedAbilityResponse>>(getList);
        return response;
    }

    [CacheRemoveAspect("IAbilityService.Get")]
    public async Task<UpdatedAbilityResponse> UpdateAsync(UpdateAbilityRequest updateAbilityRequest)
    {
        var result = await _abilityDal.GetAsync(predicate: a => a.Id == updateAbilityRequest.Id);
        _mapper.Map(updateAbilityRequest, result);
        await _abilityDal.UpdateAsync(result);
        UpdatedAbilityResponse response = _mapper.Map<UpdatedAbilityResponse>(result);
        return response;
    }
}