using Business.Dtos.LiveCourse.Requests;
using Business.Dtos.LiveCourse.Responses;
using Core.DataAccess.Paging;
using Core.Utilities.Business.Requests;

namespace Business.Abstracts;

public interface ILiveCourseService
{
    Task<IPaginate<GetListedLiveCourseResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedLiveCourseResponse> AddAsync(CreateLiveCourseRequest createLiveCourseRequest);
    Task<UpdatedLiveCourseResponse> UpdateAsync(UpdateLiveCourseRequest updateLiveCourseRequest);
    Task<DeletedLiveCourseResponse> DeleteAsync(DeleteLiveCourseRequest deleteLiveCourseRequest);
    Task<GetLiveCourseResponse> GetById(GetLiveCourseRequest getLiveCourseRequest);
}