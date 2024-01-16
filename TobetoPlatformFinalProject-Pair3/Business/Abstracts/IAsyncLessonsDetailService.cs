using Business.Dtos.AsyncLessonsDetail.Requests;
using Business.Dtos.AsyncLessonsDetail.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAsyncLessonsDetailService
{
    Task<IPaginate<GetListedAsyncLessonsDetailResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAsyncLessonsDetailResponse> AddAsync(CreateAsyncLessonsDetailRequest createAsyncLessonsDetailRequest);
    Task<UpdatedAsyncLessonsDetailResponse> UpdateAsync(UpdateAsyncLessonsDetailRequest updateAsyncLessonsDetailRequest);
    Task<DeletedAsyncLessonsDetailResponse> DeleteAsync(DeleteAsyncLessonsDetailRequest deleteAsyncLessonsDetailRequest);
    Task<GetAsyncLessonsDetailResponse> GetById(GetAsyncLessonsDetailRequest getAsyncLessonsDetailRequest);
}