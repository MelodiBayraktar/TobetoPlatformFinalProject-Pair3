using AutoMapper;
using Business.Abstracts;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities;

using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ForeignLanguageManager : IForeignLanguageService
{
    private IForeignLanguageDal _foreignLanguageDal;
    private IMapper _mapper;

    public ForeignLanguageManager(IForeignLanguageDal foreignLanguageDal, IMapper mapper)
    {
        _foreignLanguageDal = foreignLanguageDal;
        _mapper = mapper;
    }

    public async Task<CreatedForeignLanguageResponse> AddAsync(CreateForeignLanguageRequest createForeignLanguageRequest)
    {
        var foreignLanguage = _mapper.Map<ForeignLanguage>(createForeignLanguageRequest);
        var createForeignLanguage = await _foreignLanguageDal.AddAsync(foreignLanguage);
        return _mapper.Map<CreatedForeignLanguageResponse>(createForeignLanguage);
    }

    public async Task<DeletedForeignLanguageResponse> DeleteAsync(DeleteForeignLanguageRequest deleteForeignLanguageRequest)
    {
        var foreignLanguage = await _foreignLanguageDal.GetAsync(c => c.Id == deleteForeignLanguageRequest.Id);
        var deleteForeignLanguage = await _foreignLanguageDal.DeleteAsync(foreignLanguage);
        return _mapper.Map<DeletedForeignLanguageResponse>(deleteForeignLanguage);
    }

    public async Task<GetForeignLanguageResponse> GetById(GetForeignLanguageRequest getForeignLanguageRequest)
    {
        var getForeignLanguage = await _foreignLanguageDal.GetAsync(c => c.Id == getForeignLanguageRequest.Id);
        return _mapper.Map<GetForeignLanguageResponse>(getForeignLanguage);
    }

    public async Task<IPaginate<GetListedForeignLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _foreignLanguageDal.GetListAsync(include: p => p.Include(p => p.User), index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedForeignLanguageResponse>>(getList);
    }

    public async Task<UpdatedForeignLanguageResponse> UpdateAsync(UpdateForeignLanguageRequest updateForeignLanguageRequest)
    {
        var foreignLanguage = _mapper.Map<ForeignLanguage>(updateForeignLanguageRequest);
        var updatedForeignLanguage = await _foreignLanguageDal.UpdateAsync(foreignLanguage);
        return _mapper.Map<UpdatedForeignLanguageResponse>(updatedForeignLanguage);
    }
}