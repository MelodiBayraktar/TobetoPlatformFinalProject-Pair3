using Business.Dtos.Settings.Requests;
using Business.Dtos.Settings.Responses;

namespace Business.Abstracts;

public interface ISettingsService
{
    Task<UpdatedSettingsResponse> UpdateAsync(UpdateSettingsRequest updateSettingsRequest);
    Task<DeletedSettingsResponse> DeleteAsync(DeleteSettingsRequest deleteSettingsRequest);
}