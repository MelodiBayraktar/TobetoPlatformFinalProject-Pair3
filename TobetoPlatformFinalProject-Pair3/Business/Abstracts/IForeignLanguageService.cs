using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IForeignLanguageService
{
    Task<IPaginate<GetListedForeignLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedForeignLanguageResponse> AddAsync(CreateForeignLanguageRequest createForeignLanguageRequest);
    Task<UpdatedForeignLanguageResponse> UpdateAsync(UpdateForeignLanguageRequest updateForeignLanguageRequest);
    Task<DeletedForeignLanguageResponse> DeleteAsync(DeleteForeignLanguageRequest deleteForeignLanguageRequest);
    Task<GetForeignLanguageResponse> GetById(GetForeignLanguageRequest getForeignLanguageRequest);
}