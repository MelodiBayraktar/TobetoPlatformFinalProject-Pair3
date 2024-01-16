using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAsyncContentService
{
    Task<IPaginate<GetListedAsyncContentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest);
    Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest);
    Task<DeletedAsyncContentResponse> DeleteAsync(DeleteAsyncContentRequest deleteAsyncContentRequest);
    Task<GetAsyncContentResponse> GetById(GetAsyncContentRequest getAsyncContentRequest);
}