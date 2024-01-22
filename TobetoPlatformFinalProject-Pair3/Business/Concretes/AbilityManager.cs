using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Business.Concretes;

public class AbilityManager : IAbilityService
{
    private IAbilityDal _abilityDal;
    private IMapper _mapper;
    private AbilityBusinessRules _abilityBusinessRules;


    public AbilityManager(IAbilityDal abilityDal, IMapper mapper, AbilityBusinessRules abilityBusinessRules)
    {
        _abilityDal = abilityDal;
        _mapper = mapper;
        _abilityBusinessRules = abilityBusinessRules;
    }

    [SecuredOperation("admin")]

    public async Task<CreatedAbilityResponse> AddAsync(CreateAbilityRequest createAbilityRequest)
    {
        //var ability = _mapper.Map<Ability>(createAbilityRequest);
        //await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);

        //var createAbility = await _abilityDal.AddAsync(ability);
        //return _mapper.Map<CreatedAbilityResponse>(createAbility);
        var ability = _mapper.Map<Ability>(createAbilityRequest);
        await _abilityBusinessRules.AbilityShouldExistWhenSelected(ability);
        Expression<Func<Ability, object>> includeExpressionForUser = x => x.User;

        var createAbility = await _abilityDal.AddAsync(ability, includeExpressionForUser);

        return _mapper.Map<CreatedAbilityResponse>(createAbility);
    }

    public async Task<DeletedAbilityResponse> DeleteAsync(DeleteAbilityRequest deleteAbilityRequest)
    {
        var ability = await _abilityDal.GetAsync(c => c.Id == deleteAbilityRequest.Id);
        var deleteAbility = await _abilityDal.DeleteAsync(ability);
        return _mapper.Map<DeletedAbilityResponse>(deleteAbility);
    }

    public async Task<GetAbilityResponse> GetById(GetAbilityRequest getAbilityRequest)
    {
        var getAbility = await _abilityDal.GetAsync(c => c.Id == getAbilityRequest.Id);
        return _mapper.Map<GetAbilityResponse>(getAbility);
    }

    public async Task<IPaginate<GetListedAbilityResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _abilityDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);

        return _mapper.Map<Paginate<GetListedAbilityResponse>>(getList);
    }

    public async Task<UpdatedAbilityResponse> UpdateAsync(UpdateAbilityRequest updateAbilityRequest)
    {
        var ability = _mapper.Map<Ability>(updateAbilityRequest);
        var updatedAbility = await _abilityDal.UpdateAsync(ability);
        return _mapper.Map<UpdatedAbilityResponse>(updatedAbility);
    }
}