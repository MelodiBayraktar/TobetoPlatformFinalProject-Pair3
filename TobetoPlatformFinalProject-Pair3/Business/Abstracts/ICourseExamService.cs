using Business.Dtos.CourseExam.Requests;
using Business.Dtos.CourseExam.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICourseExamService
{
    Task<IPaginate<GetListedCourseExamResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCourseExamResponse> AddAsync(CreateCourseExamRequest createCourseExamRequest);
    Task<UpdatedCourseExamResponse> UpdateAsync(UpdateCourseExamRequest updateCourseExamRequest);
    Task<DeletedCourseExamResponse> DeleteAsync(DeleteCourseExamRequest deleteCourseExamRequest);
    Task<GetCourseExamResponse> GetById(GetCourseExamRequest getCourseExamRequest);
}