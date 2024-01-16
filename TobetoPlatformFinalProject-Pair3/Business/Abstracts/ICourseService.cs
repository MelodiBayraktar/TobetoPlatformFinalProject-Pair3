using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface ICourseService
{
    Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest);
    Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest);
    Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest);
    Task<GetCourseResponse> GetById(GetCourseRequest getCourseRequest);
}