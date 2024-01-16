using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IAsyncLessonsDetailService
{
    Task<IPaginate<GetListedAsyncLessonsDetailResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAsyncLessonsDetailResponse> AddAsync(CreateAsyncLessonsDetailRequest createAsyncLessonsDetailRequest);
    Task<UpdatedAsyncLessonsDetailResponse> UpdateAsync(UpdateAsyncLessonsDetailRequest updateAsyncLessonsDetailRequest);
    Task<DeletedAsyncLessonsDetailResponse> DeleteAsync(DeleteAsyncLessonsDetailRequest deleteAsyncLessonsDetailRequest);
    Task<GetAsyncLessonsDetailResponse> GetById(GetAsyncLessonsDetailRequest getAsyncLessonsDetailRequest);
}