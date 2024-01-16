using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExperienceService
{
    Task<IPaginate<GetListedExperienceResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedExperienceResponse> AddAsync(CreateExperienceRequest createExperienceRequest);
    Task<UpdatedExperienceResponse> UpdateAsync(UpdateExperienceRequest updateExperienceRequest);
    Task<DeletedExperienceResponse> DeleteAsync(DeleteExperienceRequest deleteExperienceRequest);
    Task<GetExperienceResponse> GetById(GetExperienceRequest getExperienceRequest);
}