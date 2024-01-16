using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILiveContentService
{
    Task<IPaginate<GetListedLiveContentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedLiveContentResponse> AddAsync(CreateLiveContentRequest createLiveContentRequest);
    Task<UpdatedLiveContentResponse> UpdateAsync(UpdateLiveContentRequest updateLiveContentRequest);
    Task<DeletedLiveContentResponse> DeleteAsync(DeleteLiveContentRequest deleteLiveContentRequest);
    Task<GetLiveContentResponse> GetById(GetLiveContentRequest getLiveContentRequest);
}