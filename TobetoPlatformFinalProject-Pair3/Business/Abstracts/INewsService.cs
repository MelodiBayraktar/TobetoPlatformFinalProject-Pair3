using Business.Dtos.News.Requests;
using Business.Dtos.News.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface INewsService
{
    Task<IPaginate<GetListedNewsResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedNewsResponse> AddAsync(CreateNewsRequest createNewsRequest);
    Task<UpdatedNewsResponse> UpdateAsync(UpdateNewsRequest updateNewsRequest);
    Task<DeletedNewsResponse> DeleteAsync(DeleteNewsRequest deleteNewsRequest);
    Task<GetNewsResponse> GetById(GetNewsRequest getNewsRequest);
}