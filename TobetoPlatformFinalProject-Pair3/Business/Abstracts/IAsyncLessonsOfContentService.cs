using Business.Dtos.AsyncLessonsOfContent.Requests;
using Business.Dtos.AsyncLessonsOfContent.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IAsyncLessonsOfContentService
{
    Task<IPaginate<GetListedAsyncLessonsOfContentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAsyncLessonsOfContentResponse> AddAsync(CreateAsyncLessonsOfContentRequest createAsyncLessonsOfContentRequest);
    Task<UpdatedAsyncLessonsOfContentResponse> UpdateAsync(UpdateAsyncLessonsOfContentRequest updateAsyncLessonsOfContentRequest);
    Task<DeletedAsyncLessonsOfContentResponse> DeleteAsync(DeleteAsyncLessonsOfContentRequest deleteAsyncLessonsOfContentRequest);
    Task<GetAsyncLessonsOfContentResponse> GetById(GetAsyncLessonsOfContentRequest getAsyncLessonsOfContentRequest);
}