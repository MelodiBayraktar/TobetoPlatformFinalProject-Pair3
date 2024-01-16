using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface ILiveContentService
{
    Task<IPaginate<GetListedLiveContentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedLiveContentResponse> AddAsync(CreateLiveContentRequest createLiveContentRequest);
    Task<UpdatedLiveContentResponse> UpdateAsync(UpdateLiveContentRequest updateLiveContentRequest);
    Task<DeletedLiveContentResponse> DeleteAsync(DeleteLiveContentRequest deleteLiveContentRequest);
    Task<GetLiveContentResponse> GetById(GetLiveContentRequest getLiveContentRequest);
}