using Business.Dtos.Ability.Requests;
using Business.Dtos.Ability.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAbilityService
{
    Task<IPaginate<GetListedAbilityResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAbilityResponse> AddAsync(CreateAbilityRequest createAbilityRequest);
    Task<UpdatedAbilityResponse> UpdateAsync(UpdateAbilityRequest updateAbilityRequest);
    Task<DeletedAbilityResponse> DeleteAsync(DeleteAbilityRequest deleteAbilityRequest);
    Task<GetAbilityResponse> GetById(GetAbilityRequest getAbilityRequest);
}