using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Settings.Requests;
using Business.Dtos.Settings.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;

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

    public async Task<CreatedSettingsResponse> AddAsync(CreateSettingsRequest createSettingsRequest)
    {
        var settings = _mapper.Map<Settings>(createSettingsRequest);
        var createSettings = await _settingsDal.AddAsync(settings);
        return _mapper.Map<CreatedSettingsResponse>(createSettings);
    }

    public async Task<DeletedSettingsResponse> DeleteAsync(DeleteSettingsRequest deleteSettingsRequest)
    {
        var settings = await _settingsDal.GetAsync(c => c.Id == deleteSettingsRequest.Id);
        var deleteSettings = await _settingsDal.DeleteAsync(settings);
        return _mapper.Map<DeletedSettingsResponse>(deleteSettings);
    }
    

    public async Task<IPaginate<GetListedSettingsResponse>> GetListAsync(PageRequest pageRequest)
    {
        var getList = await _settingsDal.GetListAsync(index: pageRequest.Index, size: pageRequest.Size);
        return _mapper.Map<Paginate<GetListedSettingsResponse>>(getList);
    }

    public async Task<UpdatedSettingsResponse> UpdateAsync(UpdateSettingsRequest updateSettingsRequest)
    {
        var settings = _mapper.Map<Settings>(updateSettingsRequest);
        var updatedSettings = await _settingsDal.UpdateAsync(settings);
        return _mapper.Map<UpdatedSettingsResponse>(updatedSettings);
    }
}