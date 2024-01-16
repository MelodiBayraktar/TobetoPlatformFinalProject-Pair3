using Business.Dtos.CourseDetail.Requests;
using Business.Dtos.CourseDetail.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICourseDetailService
{
    Task<IPaginate<GetListedCourseDetailResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCourseDetailResponse> AddAsync(CreateCourseDetailRequest createCourseDetailRequest);
    Task<UpdatedCourseDetailResponse> UpdateAsync(UpdateCourseDetailRequest updateCourseDetailRequest);
    Task<DeletedCourseDetailResponse> DeleteAsync(DeleteCourseDetailRequest deleteCourseDetailRequest);
    Task<GetCourseDetailResponse> GetById(GetCourseDetailRequest getCourseDetailRequest);
}