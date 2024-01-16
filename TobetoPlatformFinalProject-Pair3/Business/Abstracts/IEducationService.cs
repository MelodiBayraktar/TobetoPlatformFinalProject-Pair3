using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationService
{
    Task<IPaginate<GetListedEducationResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest);
    Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest);
    Task<DeletedEducationResponse> DeleteAsync(DeleteEducationRequest deleteEducationRequest);
    Task<GetEducationResponse> GetById(GetEducationRequest getEducationRequest);
}