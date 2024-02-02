using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Experience.Responses;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using Core.Utilities.Business.GetUserId;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities;

using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ForeignLanguageManager : IForeignLanguageService
{
    private IForeignLanguageDal _foreignLanguageDal;
    private IMapper _mapper;
    private IGetUserId _getUserId;
    public ForeignLanguageManager(IForeignLanguageDal foreignLanguageDal, IMapper mapper, IGetUserId getUserId)
    {
        _foreignLanguageDal = foreignLanguageDal;
        _mapper = mapper;
        _getUserId = getUserId;
    }
    [SecuredOperation("foreignLanguages.add,admin,mod")]
    [ValidationAspect(typeof(ForeignLanguageRequestValidator))]
    public async Task<CreatedForeignLanguageResponse> AddAsync(CreateForeignLanguageRequest createForeignLanguageRequest)
    {

        ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(createForeignLanguageRequest);
        Guid userId = _getUserId.GetUserIdFromHttpContext();
        foreignLanguage.UserId = userId;
        Expression<Func<ForeignLanguage, object>> includeExpressionForUser = x => x.User;
        var createForeignLanguage = await _foreignLanguageDal.AddAsync(foreignLanguage, includeExpressionForUser);
        CreatedForeignLanguageResponse response =  _mapper.Map<CreatedForeignLanguageResponse>(createForeignLanguage);
        return response;
    }

    public async Task<DeletedForeignLanguageResponse> DeleteAsync(DeleteForeignLanguageRequest deleteForeignLanguageRequest)
    {
        ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(c => c.Id == deleteForeignLanguageRequest.Id);
        var deleteForeignLanguage = await _foreignLanguageDal.DeleteAsync(foreignLanguage);
        DeletedForeignLanguageResponse response =  _mapper.Map<DeletedForeignLanguageResponse>(deleteForeignLanguage);
        return response;
    }

    public async Task<GetForeignLanguageResponse> GetById(GetForeignLanguageRequest getForeignLanguageRequest)
    {
        ForeignLanguage getForeignLanguage = await _foreignLanguageDal.GetAsync(c => c.Id == getForeignLanguageRequest.Id,
            include: p => p.Include(p => p.User));
        GetForeignLanguageResponse response = _mapper.Map<GetForeignLanguageResponse>(getForeignLanguage);
        return response;
    }

    public async Task<IPaginate<GetListedForeignLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _foreignLanguageDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        Paginate<GetListedForeignLanguageResponse> response = _mapper.Map<Paginate<GetListedForeignLanguageResponse>>(getList);
        return response;
    }

    public async Task<UpdatedForeignLanguageResponse> UpdateAsync(UpdateForeignLanguageRequest updateForeignLanguageRequest)
    {
        var result = await _foreignLanguageDal.GetAsync(predicate: a => a.Id == updateForeignLanguageRequest.Id);
        _mapper.Map(updateForeignLanguageRequest, result);
        await _foreignLanguageDal.UpdateAsync(result);
        UpdatedForeignLanguageResponse response = _mapper.Map<UpdatedForeignLanguageResponse>(result);
        return response;
    }
}