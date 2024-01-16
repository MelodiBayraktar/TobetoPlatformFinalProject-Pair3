using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IPersonalInfoService
{
    Task<IPaginate<GetListedPersonalInfoResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedPersonalInfoResponse> AddAsync(CreatePersonalInfoRequest createPersonalInfoRequest);
    Task<UpdatedPersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest updatePersonalInfoRequest);
    Task<DeletedPersonalInfoResponse> DeleteAsync(DeletePersonalInfoRequest deletePersonalInfoRequest);
    Task<GetPersonalInfoResponse> GetById(GetPersonalInfoRequest getPersonalInfoRequest);
}