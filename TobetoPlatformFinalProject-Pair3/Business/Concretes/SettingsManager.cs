using System.Linq.Expressions;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.Settings.Requests;
using Business.Dtos.Settings.Responses;
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

public class SettingsManager : ISettingsService
{
    private ISettingsDal _settingsDal;
    private IMapper _mapper;

    public SettingsManager(ISettingsDal settingsDal, IMapper mapper)
    {
        _settingsDal = settingsDal;
        _mapper = mapper;
    }

    //[SecuredOperation("settings.add,admin,mod")]
    //[ValidationAspect(typeof(SettingsRequestValidator))]
    //public async Task<CreatedSettingsResponse> AddAsync(CreateSettingsRequest createSettingsRequest)
    //{
    //    // var settings = _mapper.Map<Settings>(createSettingsRequest);
    //    // var createSettings = await _settingsDal.AddAsync(settings);
    //    // return _mapper.Map<CreatedSettingsResponse>(createSettings);
    //    var settings = _mapper.Map<Settings>(createSettingsRequest);
    //    Expression<Func<Settings, object>> includeExpressionForUser = x => x.User;

    //    var createSettings = await _settingsDal.AddAsync(settings, includeExpressionForUser);
    //    return _mapper.Map<CreatedSettingsResponse>(createSettings);
    //}

    public async Task<DeletedSettingsResponse> DeleteAsync(DeleteSettingsRequest deleteSettingsRequest)
    {
        Settings settings = await _settingsDal.GetAsync(c => c.Id == deleteSettingsRequest.Id);
        var deleteSettings = await _settingsDal.DeleteAsync(settings);
        DeletedSettingsResponse response = _mapper.Map<DeletedSettingsResponse>(deleteSettings);
        return response;
    }
    

    //public async Task<IPaginate<GetListedSettingsResponse>> GetListAsync(PageRequest pageRequest)
    //{
    //    var getList = await _settingsDal.GetListAsync(include: p => p.Include(p => p.User),index: pageRequest.Index, size: pageRequest.Size);
    //    return _mapper.Map<Paginate<GetListedSettingsResponse>>(getList);
    //}

    public async Task<UpdatedSettingsResponse> UpdateAsync(UpdateSettingsRequest updateSettingsRequest)
    {
        //TODO : business rules yazýlacak.
        var result = await _settingsDal.GetAsync(predicate: a => a.Id == updateSettingsRequest.Id);
        _mapper.Map(updateSettingsRequest, result);
        await _settingsDal.UpdateAsync(result);
        UpdatedSettingsResponse response = _mapper.Map<UpdatedSettingsResponse>(result);
        return response;
    }
}