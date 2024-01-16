using Business.Dtos.AsyncCourse.Requests;
using Business.Dtos.AsyncCourse.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface IAsyncCourseService
{
    Task<IPaginate<GetListedAsyncCourseResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedAsyncCourseResponse> AddAsync(CreateAsyncCourseRequest createAsyncCourseRequest);
    Task<UpdatedAsyncCourseResponse> UpdateAsync(UpdateAsyncCourseRequest updateAsyncCourseRequest);
    Task<DeletedAsyncCourseResponse> DeleteAsync(DeleteAsyncCourseRequest deleteAsyncCourseRequest);
    Task<GetAsyncCourseResponse> GetById(GetAsyncCourseRequest getAsyncCourseRequest);
}