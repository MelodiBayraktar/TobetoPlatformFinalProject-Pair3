using Business.Dtos.Survey.Requests;
using Business.Dtos.Survey.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface ISurveyService
{
    Task<IPaginate<GetListedSurveyResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest);
    Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest);
    Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest);
    Task<GetSurveyResponse> GetById(GetSurveyRequest getSurveyRequest);
}